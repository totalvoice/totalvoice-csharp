namespace TotalVoice.Api
{
    public class Sms : Api
    {
        public const string ROTA_SMS = "sms";

        public Sms(TotalVoiceClient Client) : base(Client)
        {
        }

        public string Enviar(string data)
        {
            Path path = new Path();
            path.Add(ROTA_SMS);

            _request.SetPath(path);
            _request.SetBody(data);
            return _client.SendRequest(_request, "POST");
        }

        public string Buscar(int Id)
        {
            Path path = new Path();
            path.Add(ROTA_SMS);
            path.Add(Id);

            _request.SetPath(path);
            return _client.SendRequest(_request, "GET");
        }

        public string Relatorio(string data)
        {
            Path path = new Path();
            path.Add(ROTA_SMS);
            path.Add("relatorio");

            _request.SetPath(path);
            return _client.SendRequest(_request, "GET");
        }
    }
}
