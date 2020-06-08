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
            "https://graph.facebook.com/", new Dictionary<EndpointType, string>{
                 {EndpointType.LIKES, "me/likes"},
                 {EndpointType.PAGE, "me/accounts"},
                {EndpointType.POSTS,"me/posts" },
                {EndpointType.FEED,"/feed" },
                {EndpointType.COMMENTS,"/comments" },
                {EndpointType.PHOTOS,"me/photos"}})
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
            stringBuilder.Append(endpointTypeDictionary[EndpointType.LIKES]);
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
        public string getPageIdEndpoint(string at)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append(endpointTypeDictionary[EndpointType.PAGE]);
            stringBuilder.Append("?access_token=");
            stringBuilder.Append(at);
            return stringBuilder.ToString();
        }
        public string getPostIdEndpoint(string pageId, string access_token)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append(pageId);
            stringBuilder.Append(endpointTypeDictionary[EndpointType.FEED]);
            stringBuilder.Append("?access_token=");
            stringBuilder.Append(access_token);
            return stringBuilder.ToString();
        }
        public string postFeedEndpoint(string pageId, string message, string pageToken)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append(pageId);
            stringBuilder.Append(endpointTypeDictionary[EndpointType.FEED]);
            stringBuilder.Append("?message="+message);
            stringBuilder.Append("&access_token="+pageToken);
            return stringBuilder.ToString();
        }
        public string postCommentEndpoint(string postId, string message, string pageToken)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append(postId);
            stringBuilder.Append(endpointTypeDictionary[EndpointType.COMMENTS]);
            stringBuilder.Append("?message=" + message);
            stringBuilder.Append("&access_token=" + pageToken);
            return stringBuilder.ToString();
        }
    }
}