using System;
using System.Collections.Generic;
using System.Text;

namespace TotalVoice.Api
{
    public class Sms : Api
    {
        public const string ROTA_SMS = "sms";

        public Sms(TotalVoiceClient Client) : base(Client)
        {
        }

        public void Enviar(IParameters parameters)
        {
            Request req = new Request();
            
            //return Client.Get(parameters);
        }

        public string Buscar(int id)
        {
            Path path = new Path();
            path.Add(ROTA_SMS);
            path.Add(id);

            _request.SetPath(path);
            return _client.Get(_request);
        }
    }
}
