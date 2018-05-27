using System;
using System.Collections.Generic;
using System.Text;
using TotalVoice.Api;

namespace TotalVoice
{
    public class TotalVoice : IClient
    {
        public const string BASE_URL = "https://api2.totalvoice.com.br";

        public string AccessToken { get; set; }        
        public string BaseUrl { get; set; }
        
        public TotalVoice(string AccessToken)
        {
            this.AccessToken = AccessToken;
            this.BaseUrl = BASE_URL;            
        }

        public TotalVoice(string AccessToken, string BaseUrl)
        {
            this.AccessToken = AccessToken;
            this.BaseUrl = BaseUrl;
        }

        public void Get()
        {
            throw new NotImplementedException();
        }

        public void Post()
        {
            throw new NotImplementedException();
        }

        public void Put()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
