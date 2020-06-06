using DistributedHome.Endpoints;
using DistributedHome.WebClient;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DistributedHome.Controllers
{
    [Authorize]
    public class PreferencesController : ApiController
    {
        private FacebookGraphEndpoint fbEndpoint;

        public PreferencesController() : base()
        {
            fbEndpoint = new FacebookGraphEndpoint();
        }

        public string Get(string id)
        {
            Console.WriteLine(id);
            string uid = User.Identity.GetUserId();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-D8SH71N\SQLEXPRESS;Initial Catalog=aspnet-HomeDistributed;Integrated Security=True");
            String checkPermsSql = "DELETE FROM[aspnet-HomeDistributed].[dbo].User_Preferences WHERE UserId = '"+uid+"'";
            SqlCommand command = new SqlCommand(checkPermsSql, conn);
            conn.Open();
            command.ExecuteNonQuery();
            //String query = "INSERT INTO dbo.User_Preferences (UserId,PrefId) VALUES (@UserId,@PrefId)";
            String query = "INSERT INTO dbo.User_Preferences (UserId,PrefId) VALUES";
            if (id.Contains("first_name")) {
                query += "('"+uid+"', 1),";
            }
            if (id.Contains("last_name"))
            {
                query += "('" + uid + "', 2),";
            }
            if (id.Contains("dob"))
            {
                query += "('" + uid + "', 2)";
            }
            if (query.Substring(query.Length - 1).Equals(",")) {
                query = query.Remove(query.Length - 1, 1);
            }
            SqlCommand command2 = new SqlCommand(query, conn);
            
            command2.ExecuteNonQuery();
            Console.WriteLine(uid);

            RestClient restClient = new RestClient();
            restClient.endpoint = fbEndpoint.getProfileEndpoint(id);
            string response = restClient.makeRequest();

            return response;
        }
    }
}
