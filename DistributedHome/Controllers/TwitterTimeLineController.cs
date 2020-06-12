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
    [Authorize]
    public class TwitterTimeLineController : ApiController
    {
        private TwitterEndpoint twEndpoint;

        public TwitterTimeLineController() : base()
        {
            twEndpoint = new TwitterEndpoint();
        }
        public string Get(string id, string token)
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

            string AuthSign =  keys.createHeader(twEndpoint.getTimeline(), "GET");
            twEndpoint.Signature(AuthSign);
            RestClient restClient = new RestClient(httpVerb.GET);
            restClient.endpoint = twEndpoint.getTimeline();
            return restClient.makeRequest(httpVerb.GET, twEndpoint.getEndpoint());
        }
    }
}
