namespace TotalVoice.Api
{
    public abstract class Api
    {
        protected IClient _client;
        protected IRequest _request;

        public const string GET    = "GET";
        public const string POST   = "POST";
        public const string PUT    = "PUT";
        public const string DELETE = "DELETE";

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
