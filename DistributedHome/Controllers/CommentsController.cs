using DistributedHome.Endpoints;
using DistributedHome.WebClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DistributedHome.Controllers
{
    [Authorize]
    public class CommentsController : ApiController
    {
        private FacebookGraphEndpoint fbEndpoint;

        public CommentsController() : base()
        {
            fbEndpoint = new FacebookGraphEndpoint();
        }

        public string Get(string id, string name)
        {
            RestClient restClient = new RestClient(httpVerb.GET);
            restClient.endpoint = fbEndpoint.getPostIdEndpoint(id, name);
            string response = restClient.makeRequest();
            return response;
        }
        public string Post([FromBody] JObject id)
        {
            string postId = (string)id["postId"];
            string message = (string)id["message"];
            string token = (string)id["token"];
            RestClient restClient = new RestClient(httpVerb.POST);
            restClient.endpoint = fbEndpoint.postCommentEndpoint(postId, message, token);
            string response = restClient.makeRequest();
            return response;
        }
    }
}
