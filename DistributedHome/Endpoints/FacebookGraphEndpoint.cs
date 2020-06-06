using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DistributedHome.Endpoints
{
    class FacebookGraphEndpoint : Endpoint
    {
        public FacebookGraphEndpoint() : base(
            "",
            "https://graph.facebook.com/me/", new Dictionary<EndpointType, string>{
                 {EndpointType.LIKES, "likes"},
                {EndpointType.POSTS,"posts" },
                {EndpointType.PHOTOS,"photos"}})
        { }

        public string getpostsEndpoint(string at)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append(endpointTypeDictionary[EndpointType.POSTS]);
            stringBuilder.Append("?access_token="+at);
            stringBuilder.Append("&fields=message,picture");
            return stringBuilder.ToString();
        }

        public string getLikesEndpoint(string at)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("likes");
            stringBuilder.Append("?access_token=" + at);
            return stringBuilder.ToString();
        }

        public string getPhotosEndpoint(string at)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append(endpointTypeDictionary[EndpointType.PHOTOS]);
            stringBuilder.Append("?");
            stringBuilder.Append("fields=");
            stringBuilder.Append("picture");
            stringBuilder.Append("&");
            stringBuilder.Append("type=");
            stringBuilder.Append("uploaded");
            stringBuilder.Append("&");
            stringBuilder.Append("access_token=");
            stringBuilder.Append(at);
            return stringBuilder.ToString();
        }
        public string getProfileEndpoint(string at)
        {
            string tok = at.Substring(at.IndexOf("at=") + 3);
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("?");
            stringBuilder.Append("fields=");
            if (at.Contains("first_name")) {
                stringBuilder.Append("first_name,");
            }
            if (at.Contains("last_name"))
            {
                stringBuilder.Append("last_name,");
            }
            if (at.Contains("birthday"))
            {
                stringBuilder.Append("birthday");
            }
            if (stringBuilder.ToString().EndsWith(","))
            {
                stringBuilder.Remove(stringBuilder.Length -1, 1);
            }
            stringBuilder.Append("&access_token=");
            stringBuilder.Append(tok);
            return stringBuilder.ToString();
        }
    }
}