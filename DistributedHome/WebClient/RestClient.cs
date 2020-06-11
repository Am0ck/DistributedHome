using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace DistributedHome.WebClient
{
    public enum httpVerb
    {
        GET,
        POST
    }
    class RestClient
    {
        public string endpoint { get; set; }

        public httpVerb httpMethod { get; set; }

        public RestClient(httpVerb hv)
        {
            endpoint = string.Empty;
            httpMethod = hv;
        }

        public string makeRequest()
        {
            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(endpoint);
            request.Method = httpMethod.ToString();

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException($"Error code: {response.StatusCode}");
                }

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }

            return strResponseValue;
        }
        public string makeRequest(httpVerb httpMethod, Dictionary<string, string> headers, string msg = null)
        {
            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(endpoint);

            request.Method = httpMethod.ToString();

            //for each header in our list (dictionary) headers
            foreach (KeyValuePair<string, string> header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            if (msg != null)
            {
                request.ContentType = "application/x-www-form-urlencoded";
                using (Stream objStream = request.GetRequestStream())
                {
                    byte[] content = ASCIIEncoding.ASCII.GetBytes("status=" + Uri.EscapeDataString(msg));
                    objStream.Write(content, 0, content.Length);
                }
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException($"Error Code: {response.StatusCode}");
                }

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            return strResponseValue;
        }
        /*
        public string tweetRequest(string secret, string message, string token) {
            //string message = "sdfsdf";

            string twitterURL = "https://api.twitter.com/1.1/statuses/update.json";

            string oauth_consumer_key = "npU8x3dfRNhnvCgTjg6gz9O62";
            string oauth_consumer_secret = "eAXEcDQ7togqXZlUhZUkXMlfJrRFVuAwhkrxgBl1ggCpnkay3H";
            string oauth_token = token; //"1268709200420638720-Huq2PohLDEk001YNIFQUERjtn7r0V1";
            string oauth_token_secret = secret; //"4RMJCtf76Adtj7HiZsvXAq7j0sHRqi1NOwFAIN4NyxPHH";

            // set the oauth version and signature method
            string oauth_version = "1.0";
            string oauth_signature_method = "HMAC-SHA1";

            // create unique request details
            string oauth_nonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
            System.TimeSpan timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
            string oauth_timestamp = Convert.ToInt64(timeSpan.TotalSeconds).ToString();

            // create oauth signature
            string baseFormat = "oauth_consumer_key={0}&oauth_nonce={1}&oauth_signature_method={2}" + "&oauth_timestamp={3}&oauth_token={4}&oauth_version={5}&status={6}";

            string baseString = string.Format(
                baseFormat,
                oauth_consumer_key,
                oauth_nonce,
                oauth_signature_method,
                oauth_timestamp, oauth_token,
                oauth_version,
                Uri.EscapeDataString(message)
            );

            string oauth_signature = null;
            using (HMACSHA1 hasher = new HMACSHA1(ASCIIEncoding.ASCII.GetBytes(Uri.EscapeDataString(oauth_consumer_secret) + "&" + Uri.EscapeDataString(oauth_token_secret))))
            {
                oauth_signature = Convert.ToBase64String(hasher.ComputeHash(ASCIIEncoding.ASCII.GetBytes("POST&" + Uri.EscapeDataString(twitterURL) + "&" + Uri.EscapeDataString(baseString))));
            }

            // create the request header
            string authorizationFormat = "OAuth oauth_consumer_key=\"{0}\", oauth_nonce=\"{1}\", " + "oauth_signature=\"{2}\", oauth_signature_method=\"{3}\", " + "oauth_timestamp=\"{4}\", oauth_token=\"{5}\", " + "oauth_version=\"{6}\"";

            string authorizationHeader = string.Format(
                authorizationFormat,
                Uri.EscapeDataString(oauth_consumer_key),
                Uri.EscapeDataString(oauth_nonce),
                Uri.EscapeDataString(oauth_signature),
                Uri.EscapeDataString(oauth_signature_method),
                Uri.EscapeDataString(oauth_timestamp),
                Uri.EscapeDataString(oauth_token),
                Uri.EscapeDataString(oauth_version)
            );

            HttpWebRequest objHttpWebRequest = (HttpWebRequest)WebRequest.Create(twitterURL);
            objHttpWebRequest.Headers.Add("Authorization", authorizationHeader);
            objHttpWebRequest.Method = "POST";
            objHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
            using (Stream objStream = objHttpWebRequest.GetRequestStream())
            {
                byte[] content = ASCIIEncoding.ASCII.GetBytes("status=" + Uri.EscapeDataString(message));
                objStream.Write(content, 0, content.Length);
            }

            var responseResult = "";

            try
            {
                //success posting
                WebResponse objWebResponse = objHttpWebRequest.GetResponse();
                StreamReader objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
                responseResult = objStreamReader.ReadToEnd().ToString();
            }
            catch (Exception ex)
            {
                responseResult = "Twitter Post Error: " + ex.Message.ToString() + ", authHeader: " + authorizationHeader;
            }
            return responseResult;
        }
        */

    }
    
}