namespace TotalVoice.Api
{
    public class Audio : Api
    {
        public const string ROTA_AUDIO = "audio";

        public Audio(TotalVoiceClient Client) : base(Client)
        {
        }

        public string Enviar(string data)
        {
            Path path = new Path();
            path.Add(ROTA_AUDIO);

            _request.SetPath(path);
            _request.SetBody(data);
            return _client.SendRequest(_request, "POST");
        }

        public string Buscar(int Id)
        {
            Path path = new Path();
            path.Add(ROTA_AUDIO);
            path.Add(Id);

            _request.SetPath(path);
            return _client.SendRequest(_request, "GET");
        }

        public string Relatorio(string data)
        {
            Path path = new Path();
            path.Add(ROTA_AUDIO);
            path.Add("relatorio");

            _request.SetPath(path);
            return _client.SendRequest(_request, "GET");
        }
    }
}
