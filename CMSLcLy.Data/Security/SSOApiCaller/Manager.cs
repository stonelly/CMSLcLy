using MAT;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CMSLcLy.Data.Security.SSOApiCaller
{
    public class Manager
    {
        private const string BACKEND_TOKEN = "I7uvii9cT4ja5nOEVtM2";
        private const string APPLICATION_DATABASES = "CMSLcLy.Data.Security.SSOApiCaller.Manager.APPLICATION_DATABASES";

        private static string ApiUrl { get { return System.Configuration.ConfigurationManager.AppSettings["MAT_SSO:ApiUrl"]; } }
        private static string ApplicationCode { get { return System.Configuration.ConfigurationManager.AppSettings["MAT_SSO:AppCode"]; } }

        public static bool HasApiUrl() => !string.IsNullOrEmpty(ApiUrl);

        public ActionResult<Guid?> AddUser(string loginToken, Guid subscriptionId, string username, string password)
        {
            var url = $"{ApiUrl}/user/AddUserToSubscription?token={loginToken}";

            try
            {
                using (var client = new HttpClient())
                {
                    var dataObj = new { subscriptionId = subscriptionId, username = username, password = password };
                    var response = client.PostAsJsonAsync(url, dataObj).Result;
                    response.EnsureSuccessStatusCode();

                    var result = response.Content.ReadAsAsync<Guid>().Result;
                    return new ActionResult<Guid?>(result);
                }
            }
            catch (Exception ex)
            {
                return new ActionResult<Guid?>(ex.Message);
            }
        }
        public ActionResult<Guid?> MigrateUser(string loginToken, Guid subscriptionId, Guid userId, string username, string password)
        {
            var url = $"{ApiUrl}/user/MigrateUser?token={loginToken}";

            try
            {
                using (var client = new HttpClient())
                {
                    var dataObj = new { subscriptionId, username, password, userId };
                    var response = client.PostAsJsonAsync(url, dataObj).Result;
                    response.EnsureSuccessStatusCode();

                    var result = response.Content.ReadAsAsync<Guid>().Result;
                    return new ActionResult<Guid?>(result);
                }
            }
            catch (Exception ex)
            {
                return new ActionResult<Guid?>(ex.Message);
            }
        }

        // todo : do
        public List<DatabaseModel> GetAvailableDatabases(string token)
        {
            var url = $"{ApiUrl}/SSO/GetAvailableDatabases?appCode={ApplicationCode}&token={token}";

            using (var client = new HttpClient())
            {
                var resp = client.GetAsync(url).Result;
                resp.EnsureSuccessStatusCode();
                return resp.Content.ReadAsAsync<List<DatabaseModel>>().Result;
            }
        }

        private List<DatabaseModel> GetDatabases()
        {
            var url = $"{ApiUrl}/SSO/GetDatabases";

            using (var client = new HttpClient())
            {
                var resp = client.GetAsync(url).Result;
                resp.EnsureSuccessStatusCode();
                return resp.Content.ReadAsAsync<List<DatabaseModel>>().Result;
            }
        }

        public string FindCacheDatabaseName(HttpContext context, Guid subscriptionId)
        {
            //context.Application[APPLICATION_DATABASES]
            // todo : FindCacheDatabaseName
            // 1) call sso to return all database name + subscriptionId ?? 
            // 2) cache it using Application
            // 3) if subscriptionId not exists, call sso to refresh the list

            List<DatabaseModel> DatabasesInCahce = (List<DatabaseModel>)context.Application[APPLICATION_DATABASES];

            if (DatabasesInCahce == null)
            {
                DatabasesInCahce = GetDatabases();
                context.Application[APPLICATION_DATABASES] = DatabasesInCahce;
            }

            var DatabaseName = DatabasesInCahce.Find(x => x.SubscriptionId == subscriptionId).DatabaseName;

            if (string.IsNullOrEmpty(DatabaseName))
            {
                DatabasesInCahce = GetDatabases();
                DatabaseName = DatabasesInCahce.Find(x => x.SubscriptionId == subscriptionId).DatabaseName;
            }
            return DatabaseName;
        }

        public string Authenticate(string username, string password)
        {
            var url = $"{ApiUrl}/Authentication/Authenticate";

            using (var client = new HttpClient())
            {
                var dataObj = new { username = username, password = password };
                var response = client.PostAsJsonAsync(url, dataObj).Result;
                response.EnsureSuccessStatusCode();

                var result = response.Content.ReadAsAsync<string>().Result;
                return result;
            }
        }

        public string GetDatabaseName(string token)
        {
            var url = $"{ApiUrl}/SSO/GetDatabaseName?appCode={ApplicationCode}&token={token}";

            using (var client = new HttpClient())
            {
                var resp = client.GetAsync(url).Result;
                resp.EnsureSuccessStatusCode();
                return resp.Content.ReadAsAsync<string>().Result;
            }
        }

        public string GetDatabaseNameByUserName(string username)
        {
            var url = $"{ApiUrl}/SSO/GetDatabaseNameByUserName?appCode={ApplicationCode}&username={username}";

            using (var client = new HttpClient())
            {
                var resp = client.GetAsync(url).Result;
                resp.EnsureSuccessStatusCode();
                return resp.Content.ReadAsAsync<string>().Result;
            }
        }

        public Guid GetSubscriptionId(string token)
        {
            var url = $"{ApiUrl}/SSO/GetSubscriptionId?appCode={ApplicationCode}&token={token}";

            using (var client = new HttpClient())
            {
                var resp = client.GetAsync(url).Result;
                resp.EnsureSuccessStatusCode();
                return resp.Content.ReadAsAsync<Guid>().Result;
            }
        }
        public string GetPassword(string token)
        {
            var url = $"{ApiUrl}/User/GetPassword?token={token}";

            using (var client = new HttpClient())
            {
                var resp = client.GetAsync(url).Result;
                resp.EnsureSuccessStatusCode();
                return resp.Content.ReadAsAsync<string>().Result;
            }
        }
        public void UpdatePassword(string token, string password)
        {
            var url = $"{ApiUrl}/User/UpdatePassword?token={token}";

            using (var client = new HttpClient())
            {
                var dataObj = new { password = password };
                var response = client.PostAsJsonAsync(url, dataObj).Result;
                response.EnsureSuccessStatusCode();
            }
        }
        public void SetPassword(string username, string password)
        {
            var url = $"{ApiUrl}/User/SetPassword?token={BACKEND_TOKEN}";

            using (var client = new HttpClient())
            {
                var dataObj = new { username = username, password = password };
                var response = client.PostAsJsonAsync(url, dataObj).Result;
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
