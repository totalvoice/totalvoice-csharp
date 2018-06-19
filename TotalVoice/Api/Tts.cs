namespace TotalVoice.Api
{
    public class Tts : Api
    {
        public const string ROTA_TTS = "tts";

        public Tts(TotalVoiceClient Client) : base(Client)
        {
        }

        public string Enviar(IParameters parameters)
        {
            Path path = new Path();
            path.Add(ROTA_TTS);

            _request.SetPath(path);
            return _client.Post(_request);
        }

        public string Buscar(int Id)
        {
            Path path = new Path();
            path.Add(ROTA_TTS);
            path.Add(Id);

            _request.SetPath(path);
            return _client.Get(_request);
        }

        public string Relatorio(IParameters parameters)
        {
            Path path = new Path();
            path.Add(ROTA_TTS);
            path.Add("relatorio");

            _request.SetPath(path);
            return _client.Get(_request);
        }
    }
}
