using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace DistributedHome.Oauth
{
    public class Keys
    {
        protected string consumerKey;
        protected string consumerKeySecret;
        protected const string oauthSignatureMethod = "HMAC-SHA1";
        protected string accessToken;
        protected string accessTokenSecret;
        protected const string oauthVersion = "1.0";

        public Keys(string consumerKey, string consumerKeySecret, string accessToken, string accessTokenSecret)
        {
            this.consumerKey = consumerKey;
            this.consumerKeySecret = consumerKeySecret;
            this.accessToken = accessToken;
            this.accessTokenSecret = accessTokenSecret;
        }

        private static string CreateOAuthTimestamp()
        {

            var nowUtc = DateTime.UtcNow;
            var timeSpan = nowUtc - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var timestamp = Convert.ToInt64(timeSpan.TotalSeconds).ToString();

            return timestamp;
        }
        private string CreateOauthNonce()
        {
            var oauthNonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture)));
            return oauthNonce;
        }

        private string CreateOauthSignature(string resourceUrl, string method, string oauthNonce, string oauthTimestamp, string msg)
        {
            var baseFormat = "oauth_consumer_key={0}&oauth_nonce={1}&oauth_signature_method={2}" +
                            "&oauth_timestamp={3}&oauth_token={4}&oauth_version={5}";

            if (msg != "")
            {
                baseFormat += "&status=" + Uri.EscapeDataString(msg);
            }

            var baseString = string.Format(baseFormat,
                                        consumerKey,
                                        oauthNonce,
                                        oauthSignatureMethod,
                                        oauthTimestamp,
                                        accessToken,
                                        oauthVersion
                                        );

            baseString = string.Concat(method + "&", Uri.EscapeDataString(resourceUrl), "&", Uri.EscapeDataString(baseString));



            var compositeKey = string.Concat(Uri.EscapeDataString(consumerKeySecret), "&", Uri.EscapeDataString(accessTokenSecret));

            string oauth_signature;
            using (HMACSHA1 hasher = new HMACSHA1(ASCIIEncoding.ASCII.GetBytes(compositeKey)))
            {
                oauth_signature = Convert.ToBase64String(
                    hasher.ComputeHash(ASCIIEncoding.ASCII.GetBytes(baseString)));
            }

            string autht = Uri.EscapeDataString(oauth_signature);
            return autht;
        }

        public string createHeader(string resourceURL, string method, string msg = "")
        {

            var authNonce = CreateOauthNonce();
            var authTime = CreateOAuthTimestamp();
            var sig = CreateOauthSignature(resourceURL, method, authNonce, authTime, msg);

            StringBuilder b = new StringBuilder();
            b.Append($"OAuth oauth_consumer_key={consumerKey},");
            b.Append($"oauth_nonce={authNonce},");
            b.Append($"oauth_signature_method={oauthSignatureMethod},");
            b.Append($"oauth_timestamp={authTime},");
            b.Append($"oauth_token={accessToken},");
            b.Append($"oauth_version={oauthVersion},");
            b.Append($"oauth_signature={sig}");

            var sigBaseString = b.ToString();
            return sigBaseString;
        }
    }
}