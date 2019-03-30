using System;
using System.Collections.Generic;

namespace TotalVoice.Api
{
    public class Sms : Api
    {
        public const string ROTA_SMS = "sms";

        public Sms(TotalVoiceClient Client) : base(Client)
        {
        }

        public string Enviar(dynamic Data)
        {
            Path path = new Path();
            path.Add(ROTA_SMS);

            _request.SetPath(path);
            _request.SetBody(Data);
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

        public string Relatorio(DateTime DataInicial, DateTime DataFinal, Filter Filtros = null)
        {
            Path path = new Path();
            path.Add(ROTA_SMS);
            path.Add("relatorio");

            QueryString query = new QueryString();
            query.Add("data_inicio", DataInicial.ToString());
            query.Add("data_fim", DataFinal.ToString());

            if (Filtros != null)
            {
                Filtros.Merge(ref query);
            }

            _request.SetPath(path);
            _request.SetQuery(query);

            return _client.SendRequest(_request, "GET");
        }
    }
}
