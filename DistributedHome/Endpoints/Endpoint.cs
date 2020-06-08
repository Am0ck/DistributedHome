using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistributedHome.Endpoints
{
    public enum EndpointType
    {
        POSTS,
        PAGE,
        LIKES,
        FEED,
        COMMENTS,
        PHOTOS
    }
    abstract class Endpoint
    {
        protected string access_token;
        protected string baseEndpoint;
        protected Dictionary<EndpointType, string> endpointTypeDictionary { get; }

        public Endpoint(string access_token, string baseEndpoint, Dictionary<EndpointType, string> endpointTypeDictionary)
        {
            this.access_token = access_token;
            this.baseEndpoint = baseEndpoint;
            this.endpointTypeDictionary = endpointTypeDictionary;
        }
    }
}