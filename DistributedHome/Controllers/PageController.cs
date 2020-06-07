using DistributedHome.Endpoints;
using DistributedHome.WebClient;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DistributedHome.Controllers
{
    public class PageController : ApiController
    {
        private FacebookGraphEndpoint fbEndpoint;

        public PageController() : base()
        {
            fbEndpoint = new FacebookGraphEndpoint();
        }

        public string Get(string id)
        {
            RestClient restClient = new RestClient(httpVerb.GET);
            restClient.endpoint = fbEndpoint.getPageIdEndpoint(id);
            string response = restClient.makeRequest();
            return response;
        }
        public string Post([FromBody] JObject id)
        {
            //Console.Write(id.Values);
            string pageId = (string)id["pageId"];
            string message = (string)id["message"];
            string token = (string)id["token"];
            //id += "id";
            RestClient restClient = new RestClient(httpVerb.POST);
            restClient.endpoint = fbEndpoint.postFeedEndpoint(pageId, message, token);
            string response = restClient.makeRequest();
            return response;
        }
    }
}
