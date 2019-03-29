using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TotalVoice
{
    public class TotalVoiceClient : IClient
    {
        HttpClient Client;

        public const string BASE_URL = "https://api2.totalvoice.com.br";

        public string AccessToken { get; set; }        
        public string BaseUrl { get; set; }
        
        public TotalVoiceClient(string AccessToken)
        {
            this.AccessToken = AccessToken;
            BaseUrl = BASE_URL;

            Client = new HttpClient();
        }

        public TotalVoiceClient(string AccessToken, string BaseUrl)
        {
            this.AccessToken = AccessToken;
            this.BaseUrl = BaseUrl;
        }

        public string SendRequest(IRequest req, string method)
        {
            WebRequest request = WebRequest.Create(BaseUrl + req.GetURL());
            request.Method = method;
            request.ContentType = "application/json";
            request.Headers.Add("Access-Token", AccessToken);
            if (req.GetBody() != null && (method == "POST" || method == "PUT"))
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(req.GetBody());

                request.ContentLength = bytes.Length;
                Stream reqStream = request.GetRequestStream();
                reqStream.Write(bytes, 0, bytes.Length);
                try
                {
                    reqStream.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
                {
                    response = (HttpWebResponse)ex.Response;
                }
            }

            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);

            String responseFromServer = reader.ReadToEnd();

            reader.Close();
            resStream.Close();
            response.Close();

            return JsonConvert.DeserializeObject(responseFromServer).ToString();
        }
    }
}
