using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAT.Helper;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;

namespace CMSLcLy.Data.Security.User
{
    public class Manager : DbModels.BaseManager
    {
        //public IQueryable<UserViewModel> List(string username = null, string displayName = null, UserStatus? userStatus = null, Guid? roleId = null, Guid? belongsToEId = null)
        //{
        //    // Get list of entities that allowed to view by user's company entity
        //    var orgHierarchyList = new List<Guid>();
        //    using (var mgr = new General.OrganizationalHierarchy.Manager())
        //    {
        //        orgHierarchyList = mgr.List().Select(p => p.EntityId).ToList();
        //    }
        //    if (orgHierarchyList == null) return null;

        //    var result = ExecuteReader<UserViewModel>(SqlMaps.List(orgHierarchyList)).AsQueryable();

        //    if (!string.IsNullOrWhiteSpace(username)) result = result.Where(r => r.Username.ToLower().Contains(username.ToLower()));
        //    if (!string.IsNullOrWhiteSpace(displayName)) result = result.Where(r => r.DisplayName.ToLower().Contains(displayName.ToLower()));
        //    if (userStatus.HasValue) result = result.Where(r => r.UserStatus == userStatus);
        //    if (roleId.HasValue) result = result.Where(r => r.RoleId == roleId);
        //    if (belongsToEId.HasValue) result = result.Where(r => r.BelongsToEId == belongsToEId);

        //    return result;
        //}

        //#region Updated for Workflow ForgotPassword
        //public ActionResult UpdateWorkflowForgotPassword(UserViewModel model)
        //{
        //    var q = (from u in base.Context.Users
        //             where u.UserId == model.UserId
        //             select u).FirstOrDefault();

        //    if (q == null)
        //        return new ActionResult(MAT.Resources.GlobalResource.Msg_DataNoLongerExists);

        //    model.Password = GenerateRandomPassword();
        //    string encryptedPassword = Crypto.Encrypt(model.Password);
        //    q.ChangePasswordOnNextLogin = true;
        //    q.Username = model.Username;
        //    q.Password = encryptedPassword;

        //    BindUpdateData(model);

        //    base.Context.SaveChanges();

        //    return ActionResult.SucceededResult;
        //}

        //#endregion

        public ActionResult UpdatePassword(ChangePasswordViewModel model)
        {
            var user = (from u in Context.Users
                        where u.UserId == model.UserId
                        select u).FirstOrDefault();

            if (user == null) return new ActionResult(Resources.GlobalResource.InvalidData);

            string encryptedPassword = Crypto.Encrypt(model.NewPassword);

            user.PasswordHistory = user.Password;
            user.PasswordChangedDate = DateTime.Now;
            user.Password = encryptedPassword;

            BindUpdateData(user);
            SaveChanges();

            return ActionResult.SucceededResult;
        }

        public Guid? GetUserIdByName(string username)
        {
            var q = (from u in base.Context.Users
                     where u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                     select u.UserId).FirstOrDefault();
            if (q == Guid.Empty) return null;
            return q;
        }

        public UserViewModel Get(Guid userId)
        {
            var result = ExecuteReader<UserViewModel>(SqlMaps.Get(), new System.Data.SqlClient.SqlParameter("@UserId", userId)).FirstOrDefault();
            result.AccessToEntityIdList = (from d in Context.DataSecurityEntityAccesses where d.UserId == userId select d.AccessToEntityId).ToList();
            return result;
        }

        public void ForceSetPassword(string username, string password)
        {
            var model = (from u in base.Context.Users
                         where u.Username == username
                         select u).FirstOrDefault();

            string encryptedPassword = Crypto.Encrypt(password);

            if (model.Password != encryptedPassword)
            {
                model.Password = encryptedPassword;
                model.PasswordChangedDate = DateTime.Now;
                BindUpdateData(model);
                base.Context.SaveChanges();
            }

            //if (model == null) return new ActionResult(MAT.Resources.GlobalResource.Msg_DataNoLongerExists);
        }

        public List<Guid> GetAccessToEntityIdList(Guid userId) => (from d in Context.DataSecurityEntityAccesses where d.UserId == userId select d.AccessToEntityId).ToList();

        public IEnumerable<ActiveDirectoryUserViewModel> ListActiveDirectoryUsers(string search)
        {
            var list = new List<ActiveDirectoryUserViewModel>();
            if (string.IsNullOrEmpty(search))
                return list;

            var mgr = new General.Parameter.SystemSetting.Manager();
            var authenticationSettings = mgr.GetAuthenticationSetting();

            if (string.IsNullOrWhiteSpace(authenticationSettings.ActiveDirectoryDomain))
                return list;

            try
            {
                string ldapAddress = "LDAP://" + authenticationSettings.ActiveDirectoryDomain;
                DirectoryEntry de = new DirectoryEntry(ldapAddress);
                if(!string.IsNullOrWhiteSpace(authenticationSettings.ActiveDirectoryUsername) &&
                   !string.IsNullOrWhiteSpace(authenticationSettings.ActiveDirectoryPassword))
                {
                    de.Username = authenticationSettings.ActiveDirectoryUsername;
                    de.Password = authenticationSettings.ActiveDirectoryPassword;
                }
                DirectorySearcher ds = new DirectorySearcher(de);
                ds.Filter = "(&((&(objectCategory=Person)(objectClass=User)))(samaccountname=*" + search + "*))";
                ds.SearchScope = SearchScope.Subtree;
                var rs = ds.FindAll();
                foreach(SearchResult r in rs)
                {
                    var model = new ActiveDirectoryUserViewModel()
                    {
                        LogonName = Helper.Convert.ToString(r.GetDirectoryEntry().Properties["samaccountname"].Value),
                        FirstName = Helper.Convert.ToString(r.GetDirectoryEntry().Properties["givenName"].Value),
                        LastName = Helper.Convert.ToString(r.GetDirectoryEntry().Properties["sn"].Value),
                        DisplayName = Helper.Convert.ToString(r.GetDirectoryEntry().Properties["displayName"].Value),
                        Email = Helper.Convert.ToString(r.GetDirectoryEntry().Properties["mail"].Value)
                    };
                    if (string.IsNullOrWhiteSpace(model.FirstName) && string.IsNullOrWhiteSpace(model.LastName))
                        model.FirstName = model.DisplayName;
                    list.Add(model);
                }

                //using (var context = new PrincipalContext(ContextType.Domain, authenticationSettings.ActiveDirectoryDomain,
                //    authenticationSettings.ActiveDirectoryUsername, authenticationSettings.ActiveDirectoryPassword))
                //{
                //    using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                //    {
                //        foreach (UserPrincipal result in searcher.FindAll())
                //        {
                //            var model = new ActiveDirectoryUserViewModel()
                //            {
                //                LogonName = result.SamAccountName,
                //                FirstName = result.GivenName,
                //                LastName = result.Surname,
                //                DisplayName = result.Name,
                //                Email = result.EmailAddress
                //            };
                //            if (string.IsNullOrWhiteSpace(model.FirstName) && string.IsNullOrWhiteSpace(model.LastName))
                //                model.FirstName = model.DisplayName;
                //            list.Add(model);
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                // catch error to avoid show error in screen. Just return empty list will do
            }

            return list;
        }

        public ActionResult<Guid> Add(UserInsertViewModel model)
        {
            // Generate random password if authencation type is Active Directory
            if (model.AuthenticationType == AuthenticationType.ActiveDirectory)
            {
                model.Password = GenerateRandomPassword();
                model.ConfirmPassword = model.Password;
            }
            var validationResult = Validator.ValidateObject(model);
            if (validationResult.Failed) return new ActionResult<Guid>(validationResult);

            // validation
            if (!string.IsNullOrEmpty(model.Password) && model.Password != model.ConfirmPassword)
                return new ActionResult<Guid>(Resources.GlobalResource.PasswordAndConfirmedPasswordMustIdenticalMessage);

            // Create user info
            var resultUser = Add(model.AuthenticationType, model.FirstName, model.LastName, model.Username, model.Email, model.Password);
            if (resultUser.Failed) return new ActionResult<Guid>(resultUser);

            // Create user-role info
            var resultUserRole = UpdateRoleId(resultUser.Data, new List<Guid>() { model.RoleId });
            if (resultUserRole.Failed) return new ActionResult<Guid>(resultUserRole);

            // Create Data Access Right
            if (model.AccessToEntityIdList != null && model.AccessToEntityIdList.Count > 0)
            {
                foreach (var entityId in model.AccessToEntityIdList)
                {
                    var newDataSecurity = new DbModels.DataSecurityEntityAccess
                    {
                        DataSecurityEntityAccessId = Guid.NewGuid(),
                        UserId = resultUser.Data,
                        AccessToEntityId = entityId,
                    };
                    BindInsertData(newDataSecurity);
                    Context.DataSecurityEntityAccesses.Add(newDataSecurity);
                }
                Context.SaveChanges();
            }

            return new ActionResult<Guid>(resultUser.Data);
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="authenticationType"></param>
        /// <returns></returns>
        public ActionResult<Guid> Add(AuthenticationType authenticationType, string firstName, string lastName, string username, string email)
        {
            return Add(authenticationType, firstName, lastName, username, email, GenerateRandomPassword());
        }

        public ActionResult<Guid> Add(AuthenticationType authenticationType, string firstName, string lastName, string username, string email, string password)
        {
            if (!string.IsNullOrEmpty(email) && !Email.IsValidEmail(email))
                return new ActionResult<Guid>(MAT.Resources.GlobalResource.Msg_InvalidEmailAddress);

            // validate username is unique
            if (GetUserId(username).HasValue)
                return new ActionResult<Guid>(MAT.Resources.GlobalResource.Msg_UsernameAlreadyExists);

            // create new user if not exists
            var userId = Guid.NewGuid();

            // create in sso if exists sso url
            if (SSOApiCaller.Manager.HasApiUrl())
            {
                var apiResult = new SSOApiCaller.Manager().AddUser(MAT.Context.Profile.LoginToken, MAT.Context.Profile.SubscriptionId, username, password);
                if (apiResult.Failed) return new ActionResult<Guid>(apiResult.ValidationResult);

                userId = apiResult.Data.Value;
            }

            var user = new DbModels.User()
            {
                UserId = userId,
                UserStatus = (byte)UserStatus.Active,
                Username = username,
                AuthenticationType = (byte)authenticationType,
                FirstName = firstName,
                LastName = lastName,
                DisplayName = $"{firstName} {lastName}".Trim(),
                Email = email,
                Password = Crypto.Encrypt(password),
                PasswordChangedDate = DateTime.Now,
                EnforcePasswordPolicy = authenticationType == AuthenticationType.Application,
                EnforcePasswordExpiration = authenticationType == AuthenticationType.Application,
                ChangePasswordOnNextLogin = authenticationType == AuthenticationType.Application
            };
            BindInsertData(user);
            Context.Users.Add(user);
            SaveChanges();

            // Send email only for authencation type is Application
            if (authenticationType == AuthenticationType.Application && !string.IsNullOrWhiteSpace(email))
                EmailPassword(email, firstName, username, password);

            return new ActionResult<Guid>(userId);
        }

        public ActionResult Update(UserViewModel model)
        {
            // Update user
            var userResult = Update(model.UserId, model.UserStatus, model.FirstName, model.LastName, model.Email, model.AuthenticationType);
            if (userResult.Failed) return new ActionResult<Guid>(userResult);

            // Update user role
            var resultUserRole = UpdateRoleId(model.UserId, new List<Guid>() { model.RoleId });
            if (resultUserRole.Failed) return new ActionResult<Guid>(resultUserRole);

            // Update Data Access Right
            var ds = (from d in Context.DataSecurityEntityAccesses where d.UserId == model.UserId select d);
            foreach (var d in (from d in Context.DataSecurityEntityAccesses where d.UserId == model.UserId select d))
            {
                Context.DataSecurityEntityAccesses.Remove(d);
            }

            if (model.AccessToEntityIdList != null && model.AccessToEntityIdList.Count > 0)
            {
                foreach (var entityId in model.AccessToEntityIdList)
                {
                    var newDataSecurity = new DbModels.DataSecurityEntityAccess
                    {
                        DataSecurityEntityAccessId = Guid.NewGuid(),
                        UserId = model.UserId,
                        AccessToEntityId = entityId,
                    };
                    BindInsertData(newDataSecurity);
                    Context.DataSecurityEntityAccesses.Add(newDataSecurity);
                }
            }

            Context.SaveChanges();

            return ActionResult.SucceededResult;
        }

        /// <summary>
        ///  Update user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userStatus"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="belongsToEId"></param>
        /// <returns></returns>
        public ActionResult Update(Guid userId, UserStatus userStatus, string firstName, string lastName, string email, AuthenticationType authenticationType)
        {
            var q = (from u in base.Context.Users
                     where u.UserId == userId
                     select u).FirstOrDefault();

            if (q == null)
                return new ActionResult(MAT.Resources.GlobalResource.Msg_DataNoLongerExists);

            q.AuthenticationType = (byte)authenticationType;//new
            q.UserStatus = (byte)userStatus;
            q.DisplayName = $"{firstName} {lastName}".Trim();
            q.FirstName = firstName;
            q.LastName = lastName;
            q.Email = email;

            BindUpdateData(q);

            SaveChanges();

            return ActionResult.SucceededResult;
        }

        /// <summary>
        /// Get UserId by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Guid? GetUserId(string username)
        {
            var q = (from u in base.Context.Users
                     where u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                     select u.UserId).FirstOrDefault();

            return q == default(Guid) ? null : (Guid?)q;
        }

        /// <summary>
        /// Get user's email
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetEmail(Guid userId)
        {
            return (from u in base.Context.Users
                    where u.UserId == userId
                    select u.Email).FirstOrDefault();
        }

        /// <summary>
        /// Get username
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetUsername(Guid userId)
        {
            return (from u in base.Context.Users
                    where u.UserId == userId
                    select u.Username).FirstOrDefault();
        }

        public long GetUserIntId(Guid userId)
        {
            return (from u in base.Context.Users
                    where u.UserId == userId
                    select u.UserIntId).FirstOrDefault();
        }

        /// <summary>
        /// Get User's display name
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetDisplayName(Guid userId)
        {
            var q = (from u in base.Context.Users
                     where u.UserId == userId
                     select new { u.FirstName, u.LastName }).FirstOrDefault();

            if (q == null)
                return string.Empty;

            return string.Format("{0} {1}", q.FirstName, q.LastName).Trim();
        }

        public Guid GetRoleId(Guid userId)
        {
            return (from u in base.Context.UserRoles
                    where u.UserId == userId
                    select u.RoleId).FirstOrDefault();
        }

        public ActionResult Delete(Guid userId)
        {
            var user = Context.Users.Find(userId);
            var userRoles = Context.UserRoles.Where(r => r.UserId == userId).ToList();
            userRoles.ForEach(r => Context.UserRoles.Remove(r));

            Context.Users.Remove(user);

            SaveChanges();

            return ActionResult.SucceededResult;
        }

        public string GetPasswordPolicyMessage()
        {
            General.Parameter.SystemSetting.PasswordPolicyViewModel passwordPolicy;
            using (var mgr = new General.Parameter.SystemSetting.Manager())
            {
                passwordPolicy = mgr.GetPasswordPolicySetting();
            }
            return PasswordUtil.PasswordPolicyMessage(
                passwordPolicy.MinimumPasswordLength ?? 0,
                passwordPolicy.MinimumUpperCaseLetters ?? 0,
                passwordPolicy.MinimumLowerCaseLetters ?? 0,
                passwordPolicy.MinimumNumerals ?? 0,
                passwordPolicy.MinimumSpecialCharacters ?? 0);
        }

        public ActionResult ChangePassword(ChangePasswordViewModel item)
        {
            return ChangePassword(item.UserId, item.OldPassword, item.NewPassword, item.ConfirmNewPassword);
        }

        /// <summary>
        /// Change user's password
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <param name="confirmNewPassword"></param>
        public ActionResult ChangePassword(Guid userId, string oldPassword, string newPassword, string confirmNewPassword)
        {
            string username = this.GetUsername(userId);
            return ChangePassword(username, oldPassword, newPassword, confirmNewPassword);
        }

        /// <summary>
        /// Change user's password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <param name="confirmNewPassword"></param>
        /// <returns></returns>
        public ActionResult ChangePassword(string username, string oldPassword, string newPassword, string confirmNewPassword)
        {
            if (newPassword != confirmNewPassword)
                return new ActionResult(MAT.Resources.GlobalResource.NewPasswordMustSameWithConfirmNewPassword);
            else if (newPassword == oldPassword)
                return new ActionResult(MAT.Resources.GlobalResource.NewPasswordMustDifferentFromOldPassword);

            // Update action
            var model = (from u in base.Context.Users
                         where u.Username == username
                         select u).FirstOrDefault();

            if (model == null) return new ActionResult(MAT.Resources.GlobalResource.Msg_DataNoLongerExists);

            // compare old password
            var oldPasswordToCompare = model.Password;
            if (SSOApiCaller.Manager.HasApiUrl()) oldPasswordToCompare = new SSOApiCaller.Manager().GetPassword(MAT.Context.Profile.LoginToken);
            if (oldPasswordToCompare != Crypto.Encrypt(oldPassword)) return new ActionResult(MAT.Resources.GlobalResource.InvalidOldPassword);

            // password policy checking
            string encryptedPassword = Crypto.Encrypt(newPassword);
            if (model.EnforcePasswordPolicy)
            {
                General.Parameter.SystemSetting.PasswordPolicyViewModel passwordPolicy;
                using (var mgr = new General.Parameter.SystemSetting.Manager())
                {
                    passwordPolicy = mgr.GetPasswordPolicySetting();
                }

                if (newPassword.Length < passwordPolicy.MinimumPasswordLength)
                    return new ActionResult(string.Format(Resources.GlobalResource.PasswordMustHaveAtLeastCharacters, passwordPolicy.MinimumPasswordLength));
                else if (!PasswordUtil.ValidatePassword(newPassword,
                    passwordPolicy.MinimumPasswordLength ?? 0,
                    passwordPolicy.MinimumUpperCaseLetters ?? 0,
                    passwordPolicy.MinimumLowerCaseLetters ?? 0,
                    passwordPolicy.MinimumNumerals ?? 0,
                    passwordPolicy.MinimumSpecialCharacters ?? 0))
                    return new ActionResult(string.Format(PasswordUtil.PasswordPolicyMessage((int)passwordPolicy.MinimumPasswordLength, (int)passwordPolicy.MinimumUpperCaseLetters, (int)passwordPolicy.MinimumLowerCaseLetters, (int)passwordPolicy.MinimumNumerals, (int)passwordPolicy.MinimumSpecialCharacters)));

                // check password history
                if (passwordPolicy.NumberOfPasswordHistory > 0)
                {
                    if (string.IsNullOrEmpty(model.PasswordHistory))
                    {
                        model.PasswordHistory = Crypto.Encrypt(oldPassword);
                    }
                    else
                    {
                        var passwordHistory = model.PasswordHistory.Split(',');
                        foreach (var item in passwordHistory)
                        {
                            if (encryptedPassword == item.Trim()) return new ActionResult(string.Format(Resources.GlobalResource.PasswordPolicyMsg6, passwordPolicy.NumberOfPasswordHistory));
                        }

                        // update password history
                        var newPasswordHistory = passwordHistory.Take((int)passwordPolicy.NumberOfPasswordHistory - 1).ToList();
                        newPasswordHistory.Insert(0, Crypto.Encrypt(oldPassword));
                        model.PasswordHistory = string.Join(",", newPasswordHistory);
                    }
                }
            }

            // apply encryption before compare in database
            model.ChangePasswordOnNextLogin = false;    // reset flag
            model.Password = encryptedPassword;
            model.PasswordChangedDate = DateTime.Now;
            BindUpdateData(model);
            base.Context.SaveChanges();

            if (SSOApiCaller.Manager.HasApiUrl()) new SSOApiCaller.Manager().UpdatePassword(MAT.Context.Profile.LoginToken, newPassword);

            return ActionResult.SucceededResult;
        }

        /// <summary>
        /// Check if this username required to change password due to password policy setting
        /// </summary>
        /// <param name="username"></param>
        /// <returns>return true if password required to change</returns>
        public ActionResult NotRequiredToChangePassword(string username)
        {
            var item = (from u in Context.Users
                        where u.Username.Equals(username)
                        select u).FirstOrDefault();

            // check if user forced to change password
            if (item.ChangePasswordOnNextLogin) return new ActionResult(Resources.GlobalResource.PasswordPolicyMsg_RequiredChangePasswordOnLogin);


            // check on password expiration
            if (item.EnforcePasswordExpiration)
            {
                General.Parameter.SystemSetting.PasswordPolicyViewModel policy;
                using (var mgr = new General.Parameter.SystemSetting.Manager())
                {
                    policy = mgr.GetPasswordPolicySetting();
                }

                // calculate expiration date of the password
                if (policy.PasswordAge > 0)
                {
                    var expirationDate = item.PasswordChangedDate.AddDays((double)policy.PasswordAge);
                    if (DateTime.Now.Date >= expirationDate.Date) return new ActionResult(Resources.GlobalResource.PasswordPolicyMsg_PasswordExpired);
                }
            }

            return ActionResult.SucceededResult;
        }

        public ActionResult Unlock(string username)
        {
            var user = (from u in base.Context.Users
                        where u.Username.Equals(username)
                        select u).FirstOrDefault();

            user.LoginAttempt = 0;
            user.UserStatus = (byte)UserStatus.Active;

            SaveChanges();

            return ActionResult.SucceededResult;
        }

        /// <summary>
        /// Validate combination of username & password is valid
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ActionResult Login(string username, string password)
        {
            var user = (from u in base.Context.Users
                        where u.Username.Equals(username)
                        select u).FirstOrDefault();

            if (user == null) return new ActionResult(Resources.GlobalResource.LoginFailed);

            // check status
            if ((UserStatus)user.UserStatus == UserStatus.Locked) return new ActionResult(Resources.GlobalResource.MsgLogin_AccountLocked);
            else
            {
                if ((UserStatus)user.UserStatus == UserStatus.Inactive) return new ActionResult(Resources.GlobalResource.LoginFailed);
            }

            // check login attempt
            var loginAttempt = user.LoginAttempt.HasValue ? user.LoginAttempt.Value : 0;

            if (user.AuthenticationType == (byte)AuthenticationType.Application)
            {
                // check password separately for account lock checking
                string encryptedPassword = Crypto.Encrypt(password);
                if (user.Password != encryptedPassword)
                {
                    // check login attempt
                    using (var mgr = new App.General.Parameter.SystemSetting.Manager())
                    {
                        var policy = mgr.GetPasswordPolicySetting();
                        if (policy.AccountLockoutThreshold > 0)
                        {
                            user.LoginAttempt = loginAttempt + 1;

                            // lock user account if exceed AccountLockoutThreshold
                            if (user.LoginAttempt >= policy.AccountLockoutThreshold) user.UserStatus = (byte)UserStatus.Locked;

                            // save change on loginAttempt counter
                            SaveChanges();
                        }
                    }

                    return new ActionResult(Resources.GlobalResource.LoginFailed);
                }
            }
            else if (user.AuthenticationType == (byte)AuthenticationType.ActiveDirectory)
            {
                //var adLogin = username.Split(new char[] { '\\' });
                //if (adLogin.Length != 2) return new ActionResult(Resources.GlobalResource.LoginFailed); // failed if ad user login not in format {domain}\{user}
                string adDomain;
                using (var mgr = new App.General.Parameter.SystemSetting.Manager())
                {
                    adDomain = mgr.GetAuthenticationSetting().ActiveDirectoryDomain;
                }
                var path = string.Format("LDAP://{0}", adDomain);
                var entry = new DirectoryEntry(path, username, password);

                try
                {   //Bind to the native AdsObject to force authentication.			
                    var obj = entry.NativeObject;
                    var search = new DirectorySearcher(entry);
                    return new ActionResult();
                }
                catch (Exception ex)
                {
                    return new ActionResult(ex.GetBaseException().Message);
                }
            }
            else
            {
                return new ActionResult(Resources.GlobalResource.LoginFailed);
            }

            // update login info
            user.LastLoginDate = DateTime.Now;
            user.LoginAttempt = 0;
            SaveChanges();

            return ActionResult.SucceededResult;
        }

        /// <summary>
        /// Validate if username is valid
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public ActionResult DomainLogin(string username)
        {
            var user = (from u in base.Context.Users
                        where u.Username.Equals(username)
                        select u).FirstOrDefault();

            if (user == null) return new ActionResult(Resources.GlobalResource.LoginFailed);

            // check status
            if ((UserStatus)user.UserStatus == UserStatus.Locked)
                return new ActionResult(Resources.GlobalResource.MsgLogin_AccountLocked);
            else if ((UserStatus)user.UserStatus == UserStatus.Inactive)
                return new ActionResult(Resources.GlobalResource.MsgLogin_AccountInactive);

            // update login info
            user.LastLoginDate = DateTime.Now;
            user.LoginAttempt = 0;
            SaveChanges();

            return ActionResult.SucceededResult;
        }

        /// <summary>
        /// Reset user's password randomly
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public ActionResult<ResetPasswordViewModel> ResetPassword(string username)
        {
            var userId = GetUserId(username);
            if (!userId.HasValue)
                return new ActionResult<ResetPasswordViewModel>(Resources.GlobalResource.Msg_InvalidUsername);

            var userData = Get(userId.Value);
            if (userData.AuthenticationType == AuthenticationType.ActiveDirectory)
                return new ActionResult<ResetPasswordViewModel>(Resources.GlobalResource.Message_ResetPasswordNotApplicableForADUser);

            var email = GetEmail(userId.Value);

            if (string.IsNullOrEmpty(email))
                return new ActionResult<ResetPasswordViewModel>(Resources.GlobalResource.Msg_UserDoNotHaveEmailSpecified);

            var newPassword = GenerateRandomPassword();
            var updateMdl = (from u in base.Context.Users
                             where u.UserId == userId.Value
                             select u).FirstOrDefault();
            if (updateMdl == null)
                return new ActionResult<ResetPasswordViewModel>(Resources.GlobalResource.Msg_DataNoLongerExists);
            // apply encryption before compare in database
            string encryptedPassword = Crypto.Encrypt(newPassword);
            updateMdl.Password = encryptedPassword;
            updateMdl.ChangePasswordOnNextLogin = true;
            BindUpdateData(updateMdl);
            base.Context.SaveChanges();

            var name = GetDisplayName(userId.Value);

            // sso
            if (Security.SSOApiCaller.Manager.HasApiUrl())
            {
                new SSOApiCaller.Manager().SetPassword(username, newPassword);
            }

            ////send an email to user informaing about password reset
            //EmailResetPassword(email, name, username, newPassword);

            return new ActionResult<ResetPasswordViewModel>(
                new ResetPasswordViewModel()
                {
                    UserId = userId.Value,
                    Password = newPassword
                });
        }

        void EmailPassword(string email, string firstName, string username, string password)
        {
            string subject = "Welcome";
            string body = string.Format(@"
Dear {0},
<br/>
<br/>
Kindly login to " + AppSettings.HostUrl + @" using the following credentials:<br/>
Username : {1}<br/>
Password : {2}<br/>
<br/>
<br/>
This is an automatically generated email. Please do not reply to this message.
", firstName, username, password);


            MAT.Helper.Email.SendMail(email, subject, body, true, System.Net.Mail.MailPriority.High, null, null);
        }

        ////
        //void EmailResetPassword(string email, string firstName, string username, string password)
        //{
        //    string subject = "Reset Password";
        //    string body = string.Format(@"
        //Dear {0},
        //<br/>
        //<br/>
        //Your password has been reset. Kindly login to " + AppSettings.HostUrl + @" using the following credentials:<br/>
        //Username : {1}<br/>
        //Password : {2}<br/>
        //<br/>
        //<br/>
        //This is an automatically generated email. Please do not reply to this message.
        //", firstName, username, password);


        //    using (var con = new General.Email.Manager())
        //    {
        //        con.SendMail(email, subject, body);
        //    }
        //}

        public string GenerateRandomPassword()
        {
            return System.Web.Security.Membership.GeneratePassword(10, 0);
        }

        public ActionResult UpdateRoleId(Guid userId, List<Guid> roleIds)
        {
            // remove existing userRole data
            var existingUserRole = Context.UserRoles.Where(r => r.UserId == userId).ToList();
            existingUserRole.ForEach(r => Context.UserRoles.Remove(r));

            // add new userRole data
            foreach (var roleId in roleIds)
            {
                var newItem = new DbModels.UserRole
                {
                    UserRoleId = Guid.NewGuid(),
                    UserId = userId,
                    RoleId = roleId,
                };
                BindInsertData(newItem);
                Context.UserRoles.Add(newItem);
            }

            SaveChanges();

            return ActionResult.SucceededResult;
        }

        public string CheckDuplicateEmail(string eMail) => Context.Users.Where(r => r.Email == eMail).Select(r => r.Username).FirstOrDefault();

        public string CheckDuplicateEmailByUserId(Guid UserId, string eMail) => Context.Users.Where(r => r.Email == eMail).Where(r => r.UserId != UserId).Select(r => r.Username).FirstOrDefault();


        #region MyProfile
        public MyProfileViewModel GetMyProfileInfo(Guid employeeId)
        {
            var result = (from e in Context.Employees
                          join el in Context.EmployeeLogins on e.EmployeeId equals el.EmployeeId
                          join u in Context.Users on el.UserId equals u.UserId
                          join p in Context.People on e.PersonId equals p.PersonId
                          join ur in Context.UserRoles on u.UserId equals ur.UserId
                          where e.EmployeeId == employeeId
                          select new MyProfileViewModel
                          {
                              UserId = u.UserId,
                              EmployeeId = el.EmployeeId,
                              Email = p.Email,
                              MobilePhone = p.MobilePhone,
                              Name = u.FirstName + " " + u.LastName,
                              ProfileImagePath = p.ProfileImagePath,
                          }).FirstOrDefault();

            //get the current Department Name
            var empHistory = (from e in Context.EmployeeEmploymentHistories
                              orderby e.EffectiveDate ascending
                              where e.EmployeeId == employeeId
                              select new
                              {
                                  DepartmentName = e.Entity.Name,
                                  EffectiveDate = e.EffectiveDate,
                                  EndDate = e.EndDate,
                              })
                              .OrderBy(r => (r.EndDate == null ? DateTime.Today : r.EndDate) >= DateTime.Today && r.EffectiveDate <= DateTime.Today).FirstOrDefault();

            result.Department = empHistory.DepartmentName;

            return result;
        }

        #endregion

        public UserGroup GetUserGroup(Guid userId)
        {
            return UserGroup.External;
            // todo : check with the dbmodel
            //return (UserGroup)(from u in Context.Users
            //                   where u.UserId == userId
            //                   select u.UserGroup).FirstOrDefault();
        }

        public Guid GetEmployeeId(Guid userId)
        {
            return (from el in Context.EmployeeLogins
                    where el.UserId == userId
                    select el.EmployeeId).FirstOrDefault();
        }

        public List<Guid> GetDataSecurityAccessibleEntityIdList(Guid userId)
        {
            return (from ds in Context.DataSecurityEntityAccesses
                    where ds.UserId == userId
                    select ds.AccessToEntityId).ToList();
        }

        public void UpdateMyProfileInfo(MyProfileViewModel item)
        {
            // update profile photo
            var person = (from e in Context.Employees
                          join p in Context.People on e.PersonId equals p.PersonId
                          where e.EmployeeId == item.EmployeeId
                          select p).First();

            if (person.ProfileImagePath != item.ProfileImagePath)
            {
                person.ProfileImagePath = item.ProfileImagePath;
                BindUpdateData(person);
                SaveChanges();
            }
        }

        public Guid GetUserId(Guid employeeId)
        {
            return (from el in Context.EmployeeLogins
                    where el.EmployeeId == employeeId
                    select el.UserId).First();
        }
    }
}
