using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DistributedHome.Endpoints
{

    class TwitterEndpoint
    {
        string signature;
        string baseEndpoint = "https://api.twitter.com/";
        public void Signature(string signature)
        {
            this.signature = signature;
        }
        public string getTimeline()
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("1.1/");
            stringBuilder.Append("statuses/");
            stringBuilder.Append("user_timeline.json");
            return stringBuilder.ToString();
        }

        public string getFavourites()
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("1.1/");
            stringBuilder.Append("favorites/");
            stringBuilder.Append("list.json");
            return stringBuilder.ToString();
        }

        public string getFriends()
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("1.1/");
            stringBuilder.Append("friends/");
            stringBuilder.Append("list.json");
            return stringBuilder.ToString();
        }
        public string getFollowers()
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("1.1/");
            stringBuilder.Append("followers/");
            stringBuilder.Append("list.json");
            return stringBuilder.ToString();
        }
        public string postTweet()
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("1.1/");
            stringBuilder.Append("statuses/");
            stringBuilder.Append("update.json");
            return stringBuilder.ToString();
        }
        public string searchTweet()
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("1.1/");
            stringBuilder.Append("search/");
            stringBuilder.Append("tweets.json");
            return stringBuilder.ToString();
        }

        public Dictionary<string, string> getEndpoint()
        {
            return new Dictionary<string, string>
            {
               {"Authorization", this.signature},

            };
        }
    }
}