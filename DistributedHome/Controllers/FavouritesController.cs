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
    public class FavouritesController : ApiController
    {
        private TwitterEndpoint twEndpoint;

        public FavouritesController() : base()
        {
            twEndpoint = new TwitterEndpoint();
        }
        public string Get(string id, string token)
        {
            Console.WriteLine(id);
            Keys keys = new Keys(id, token);

            string AuthSign = keys.createHeader(twEndpoint.getFavourites(), "GET");
            twEndpoint.Signature(AuthSign);
            RestClient restClient = new RestClient(httpVerb.GET);
            restClient.endpoint = twEndpoint.getFavourites();
            return restClient.makeRequest(httpVerb.GET, twEndpoint.getEndpoint());
        }
    }
}
