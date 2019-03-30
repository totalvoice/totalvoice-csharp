using System;

namespace TotalVoice.Api
{
    /// <summary>
    /// SMS Class
    /// </summary>
    public class Sms : Api
    {
        public const string ROTA_SMS = "sms";

        public Sms(IClient Client) : base(Client) { }
        public Sms(IClient client, IRequest request) : base(client, request) { }

        /// <summary>
        /// Envia um sms para um número destino
        /// </summary>
        /// <param name="Data">Estrutura enviada para o Post.</param>
        /// 
        // Ex: 
        // var Data = new {
        //    numero_destino = "48988888888",
        //    mensagem       = "Testando SMS"
        // };
        /// 
        public string Enviar(dynamic Data)
        {
            Path path = new Path();
            path.Add(ROTA_SMS);

            _request.SetPath(path);
            _request.SetBody(Data);
            return _client.SendRequest(_request, "POST");
        }

        /// <summary>
        /// Busca um sms pelo seu ID
        /// </summary>
        /// <param name="Id">ID do SMS.</param>
        /// 
        public string Buscar(int Id)
        {
            Path path = new Path();
            path.Add(ROTA_SMS);
            path.Add(Id);

            _request.SetPath(path);
            return _client.SendRequest(_request, "GET");
        }

        /// <summary>
        /// Relatorio de envio de SMS
        /// </summary>
        /// <param name="DataInicial">Periodo inicial para a consulta</param>
        /// <param name="DataFinal">Periodo final para a consulta.</param>
        /// <param name="Filtros">Filtros adicionais que podem ser enviados.</param>
        /// 
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
