using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DistributedHome.Endpoints;
using System.Web.Mvc;
using DistributedHome.WebClient;
using System.Web.Http;
//using DistributedHome.WebClient;

namespace DistributedHome.Controllers
{
    public class FacebookController : ApiController
    {
        private FacebookGraphEndpoint fbEndpoint;

        public FacebookController() : base()
        {
            fbEndpoint = new FacebookGraphEndpoint();
        }

        public string Get(string id)
        {
            Console.WriteLine(id);
            RestClient restClient = new RestClient();
            restClient.endpoint = fbEndpoint.getpostsEndpoint(id);
            string response = restClient.makeRequest();

            return response;
        }
        //public string GetPost()
        //{
        //    restClient.endpoint = fbEndpoint.getpostsEndpoint());
        //    string response = restClient.makeRequest();

        //    return response;
        //}
        /*
        public string Get(int at)
        {
            RestClient restClient = new RestClient();
            restClient.endpoint = fbEndpoint.getpostsEndpoint("EAAJGiKNXmeUBAOek22saJfsz1UUSMIeqRTtuF3x6DRFcP0dZCqnZBP58CpUnDKQAnkEuJN953praO0WnFr3gpX7Y1zTuNb8oGqgoBZBCmvc8cUQjyAxS5ZCYN6drKZBZBvmam1ti4M5bvPc4qZABj5j39kGZCZCKEQcQxpKjlOOBgITg0hgL0pt2U5iLf86vMCRAAhWnf3FDiCmcdWZAMupqMjVsD5T87VlPdFDTWVQtER2l5QIdYRzuaQZBSHbUdRjc5gZD");
            string response = restClient.makeRequest();

            return response;
        }
        */
    }
}