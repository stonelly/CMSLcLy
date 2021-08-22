using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAT.Helper;
using System.Data;

namespace CMSLcLy.Data.Security.Role
{
    public class Manager : DbModels.BaseManager
    { 

        public ActionResult<Guid> Add(RoleMasterViewModel model)
        {
            // create role with function assign
            var newRole = new DbModels.Role
            {
                RoleId = Guid.NewGuid(),
                Name = model.Name,
            };
            BindInsertData(newRole);
            Context.Roles.Add(newRole);

            foreach (var functionId in model.RoleFunctions.Keys)
            {
                var newRoleFunction = new DbModels.RoleFunction
                {
                    RoleFunctionId = Guid.NewGuid(),
                    RoleId = newRole.RoleId,
                    FunctionId = functionId,
                    AccessControlCode = string.Join(",", model.RoleFunctions[functionId]),
                };
                BindInsertData(newRoleFunction);
                Context.RoleFunctions.Add(newRoleFunction);
            }

            SaveChanges();

            return new ActionResult<Guid>(newRole.RoleId);
        }

        public void AddUserToRole(out Guid userRoleId, Guid entityId, Guid userId, Guid roleId)
        {
            // skip the add if already added before
            var q = (from ur in Context.UserRoles
                     where ur.RoleId == roleId
                     && ur.UserId == userId
                     select ur.UserRoleId).FirstOrDefault();

            if (q != default(Guid))
            {
                userRoleId = q;
                return;
            }

            // create user role if not exists
            userRoleId = Guid.NewGuid();
            var entity = new DbModels.UserRole()
            {
                UserRoleId = userRoleId,
                UserId = userId,
                RoleId = roleId
            };
            base.BindInsertData(entity);
            Context.UserRoles.Add(entity);
            Context.SaveChanges();
        }

        public IQueryable<RoleMasterViewModel> List(string name = null)
        {
            var q = from r in Context.Roles
                    select new RoleMasterViewModel
                    {
                        RoleId = r.RoleId,
                        Name = r.Name,
                        ModifiedDate = r.ModifiedDate
                    };

            // filters
            if (!string.IsNullOrWhiteSpace(name)) q = q.Where(r => r.Name.Contains(name));

            return q;
        }

        public ActionResult Delete(Guid roleId)
        {
            var userRoles = (from ur in Context.UserRoles
                             where ur.RoleId == roleId
                             select ur).ToList();
            userRoles.ForEach(r => Context.UserRoles.Remove(r));

            var roleFunctions = (from rf in Context.RoleFunctions
                                 where rf.RoleId == roleId
                                 select rf).ToList();
            roleFunctions.ForEach(r => Context.RoleFunctions.Remove(r));

            var role = Context.Roles.Find(roleId);
            Context.Roles.Remove(role);

            Context.SaveChanges();

            return ActionResult.SucceededResult;
        }

        public Guid? GetRoleIdByName(string name)
        {
            var roleId = (from r in Context.Roles
                          where r.Name == name
                          select r.RoleId).FirstOrDefault();

            return roleId == Guid.Empty ? (Guid?)null : roleId;
        }

        public RoleMasterViewModel Get(Guid roleId)
        {
            var counter = 0;//for auditlog
            var q = (from r in Context.Roles
                     where r.RoleId == roleId
                     select new RoleMasterViewModel
                     {
                         RoleId = r.RoleId,
                         Name = r.Name,
                     }).FirstOrDefault();

            // get roleFunctions
            var roleFunctions = (from rf in Context.RoleFunctions
                                 where rf.RoleId == roleId
                                 select rf).OrderBy(r => r.FunctionId).ToList();

            // get roleFunction join Functions 
            var functions = (from rf in Context.RoleFunctions
                             join f in Context.Functions on rf.FunctionId equals f.FunctionId
                             where rf.RoleId == roleId
                             select f).OrderBy(r => r.FunctionId).ToList();

            //count the maximum length of Name
            int MAX_SIZE = 0;
            if (functions.Count() > 0 && q.RoleFunctions != null)
            {
                for (int n = 0; n < functions.Count(); n++)
                {
                    if (MAX_SIZE < functions[n].Name.Length)
                        MAX_SIZE = functions[n].Name.Length;
                }
            }

            if (q != null)
            {
                var a1 = string.Empty;

                q.RoleFunctions = new Dictionary<Guid, List<string>>();
                try
                {
                    foreach (var item in roleFunctions)
                    {

                        var convertedAccessControlCode = item.AccessControlCode;

                        if (item.AccessControlCode.Contains(','))
                        {
                            convertedAccessControlCode = string.Empty;
                            var primeArray = item.AccessControlCode.Split(',');

                            for (int i = 0; i < primeArray.Length; i += 1)
                            {
                                convertedAccessControlCode = string.Concat(convertedAccessControlCode, MAT.Helper.Resource.GetResourceText(primeArray[i]), ",");
                            }

                            convertedAccessControlCode = convertedAccessControlCode.Substring(0, convertedAccessControlCode.Length - 1);
                        }
                        else
                            convertedAccessControlCode = MAT.Helper.Resource.GetResourceText(convertedAccessControlCode);

                        q.RoleFunctions.Add(item.FunctionId, item.AccessControlCode.Split(',').Select(r => r.Trim()).ToList());
                        if (counter == 0)//fixed only first sentence will go to next line
                            q.AuditLogWriteString_UserRole = "\n";
                        a1 = functions[counter].Name;
                        if (MAT.Helper.Resource.GetResourceText(functions[counter].Name) == "Menu_FullDowngradeSummaryReport")
                            counter = counter;
                        q.AuditLogWriteString_UserRole += "\t\t" + MAT.Helper.Resource.GetResourceText(functions[counter].Name).PadRight(MAX_SIZE) + ":" + convertedAccessControlCode + "\n";

                        counter++;
                    }
                }
                catch (Exception ex)
                {

                    var a = ex.Message + "" + a1;
                }
                
            }
            return q;
        }

        public Guid? GetUserRoleId(Guid? userId)
        {
            var q = (from ur in Context.UserRoles
                     where ur.UserId == userId
                     select ur.UserRoleId).FirstOrDefault();

            return (q == default(Guid)) ? null : (Guid?)q;
        }

        DataTable SelectFullUserGroupFunctionList(Guid roleId)
        {
            string sql = SqlMap.SelectFullUserGroupFunctionList();
            return Context.ExecuteReader(
                 sql,
                 new System.Data.SqlClient.SqlParameter("@roleId", roleId)
                 );
        }

        public ActionResult Update(RoleMasterViewModel model)
        {
            var role = Context.Roles.Find(model.RoleId);
            role.Name = model.Name;
            Guid test = new Guid();
            // remove all roleFunction before add
            var roleFunctions = Context.RoleFunctions.Where(r => r.RoleId == model.RoleId).ToList();
            roleFunctions.ForEach(r => Context.RoleFunctions.Remove(r));
            foreach (var functionId in model.RoleFunctions.Keys)
            {
                if (functionId == Guid.Parse("75162F5F-0AB2-4E53-9C36-ACB24922B645"))
                    test = functionId;

                var newRoleFunction = new DbModels.RoleFunction
                {
                    RoleFunctionId = Guid.NewGuid(),
                    RoleId = model.RoleId,
                    FunctionId = functionId,
                    AccessControlCode = string.Join(",", model.RoleFunctions[functionId]),
                };
                BindInsertData(newRoleFunction);
                Context.RoleFunctions.Add(newRoleFunction);
            }

            SaveChanges();

            return new ActionResult();
        }

        public bool IsUserRoleAssigned(Guid RoleId)
        {
            var q = from ur in Context.UserRoles
                    where ur.RoleId == RoleId
                    select ur.UserId;

            if (q.Count() > 0) { return true; }
            return false;
        }
    }
}
