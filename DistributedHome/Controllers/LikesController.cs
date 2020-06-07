using DistributedHome.Endpoints;
using DistributedHome.Models;
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
    public class LikesController : ApiController
    {
        private FacebookGraphEndpoint fbEndpoint;
        private ApplicationDbContext db = new ApplicationDbContext();
        public Entities ent = new Entities();
        public LikesController() : base()
        {
            fbEndpoint = new FacebookGraphEndpoint();
        }
        public string Get(string id)
        {
            
            RestClient restClient = new RestClient(httpVerb.GET);
            restClient.endpoint = fbEndpoint.getLikesEndpoint(id);
            string response = restClient.makeRequest();

            return response;
        }
    }
}
