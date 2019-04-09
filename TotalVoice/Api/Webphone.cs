
namespace TotalVoice.Api
{
    /// <summary>
    /// Webphone Class
    /// https://totalvoice.github.io/totalvoice-docs/#webphone
    /// </summary>
    public class Webphone : Api
    {
        public const string ROTA_WEBPHONE = "webphone";

        public Webphone(IClient client) : base(client) { }
        public Webphone(IClient client, IRequest request) : base(client, request) { }

        ///
        /// <summary>
        /// Requisita a URL do webphone de um ramal
        /// </summary>
        /// 
        public string Url()
        {
            Path path = new Path();
            path.Add(ROTA_WEBPHONE);

            _request.SetPath(path);
            return _client.SendRequest(_request, GET);
        }
    }
}
