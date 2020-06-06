using DistributedHome.Endpoints;
using DistributedHome.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DistributedHome.Controllers
{
    public class PhotosController : ApiController
    {
        private FacebookGraphEndpoint fbEndpoint;

        public PhotosController() : base()
        {
            fbEndpoint = new FacebookGraphEndpoint();
        }

        public string Get(string id)
        {
            Console.WriteLine(id);
            RestClient restClient = new RestClient();
            restClient.endpoint = fbEndpoint.getPhotosEndpoint(id);
            string response = restClient.makeRequest();

            return response;
        }
    }
}
