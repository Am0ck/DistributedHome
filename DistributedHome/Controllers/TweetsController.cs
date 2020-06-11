using DistributedHome.Endpoints;
using DistributedHome.Oauth;
using DistributedHome.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DistributedHome.Controllers
{
    public class TweetsController : ApiController
    {
        private TwitterEndpoint twEndpoint;

        public TweetsController() : base()
        {
            twEndpoint = new TwitterEndpoint();
        }
        public string Post(string id, string message, string token)
        {
            Console.WriteLine(id);
            //string uid = User.Identity.GetUserId();
            //Console.WriteLine(uid);
            //TwitterRestClient restClient = new TwitterRestClient(httpVerb.GET);
            //restClient.endpoint = twEndpoint.getpostsEndpoint(id);
            //string response = restClient.makeRequest();
            //return response;
            //string ConsumerKey = "npU8x3dfRNhnvCgTjg6gz9O62";
            //string ConsumerKeySecret = "eAXEcDQ7togqXZlUhZUkXMlfJrRFVuAwhkrxgBl1ggCpnkay3H";
            //string OauthSignatureMethod = "HMAC-SHA1";
            //string AccessToken = "1268709200420638720-Huq2PohLDEk001YNIFQUERjtn7r0V1";
            //string AccessTokenSecret = "4RMJCtf76Adtj7HiZsvXAq7j0sHRqi1NOwFAIN4NyxPHH";
            //string OauthVersion = "1.0";
            Keys keys = new Keys(id, token);
            return "";
            //string AuthSign = keys.createHeader(twEndpoint.postTweet(message), "POST");
            //twEndpoint.Signature(AuthSign);
            //RestClient restClient = new RestClient(httpVerb.POST);
            //restClient.endpoint = twEndpoint.postTweet(message);
            //return restClient.makeRequest(httpVerb.POST, twEndpoint.getEndpoint());
        }
    }
}
