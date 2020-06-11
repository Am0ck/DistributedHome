using DistributedHome.Endpoints;
using DistributedHome.Oauth;
using DistributedHome.WebClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace DistributedHome.Controllers
{
    public class StatusController : ApiController
    {
        private TwitterEndpoint twEndpoint;

        public StatusController() : base()
        {
            twEndpoint = new TwitterEndpoint();
        }
        public string Post([FromBody] JObject id)
        {
            Console.WriteLine(id);
            string token = (string)id["token"];
            string message = (string)id["message"];
            string secret = (string)id["secret"];

            Keys keys = new Keys(token, secret);

            string AuthSign = keys.createHeader(twEndpoint.postTweet(), "POST", message);
            twEndpoint.Signature(AuthSign);
            RestClient restClient = new RestClient(httpVerb.POST);
            restClient.endpoint = twEndpoint.postTweet();
            return restClient.makeRequest(httpVerb.POST, twEndpoint.getEndpoint(), message);

            //RestClient restClient = new RestClient(httpVerb.POST);
            //return restClient.tweetRequest(secret, message, token);
        }
    }
}
