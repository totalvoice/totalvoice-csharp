using System;
using System.Collections.Generic;
using System.Text;

namespace TotalVoice.Api
{
    public abstract class Api
    {
        protected IClient _client;
        protected IRequest _request;

        public Api(IClient client)
        {
            _client = client;
            _request = new Request();
        }

        public Api(IClient client, IRequest request)
        {
            _client = client;
            _request = request;
        }
    }
}
