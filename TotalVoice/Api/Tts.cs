using System;

namespace TotalVoice.Api
{
    /// <summary>
    /// SMS Class
    /// </summary>
    public class Tts : Api
    {
        public const string ROTA_TTS = "tts";

        public Tts(IClient Client) : base(Client) { }
        public Tts(IClient client, IRequest request) : base(client, request) { }

        /// <summary>
        /// Envia um TTS (text-to-speach) para um número destino
        /// </summary>
        /// <param name="Data">Estrutura enviada para o Post.</param>
        /// 
        // Ex: 
        // var Data = new {
        //    numero_destino = "48988888888",
        //    mensagem       = "Testando TTS"
        // };
        /// DOCS:
        /// https://totalvoice.github.io/totalvoice-docs/#tts-leitura-de-texto
        ///
        public string Enviar(dynamic Data)
        {
            Path path = new Path();
            path.Add(ROTA_TTS);

            _request.SetPath(path);
            _request.SetBody(Data);
            return _client.SendRequest(_request, POST);
        }

        /// <summary>
        /// Busca um TTS pelo seu ID
        /// </summary>
        /// <param name="Id">ID do TTS.</param>
        /// 
        public string Buscar(int Id)
        {
            Path path = new Path();
            path.Add(ROTA_TTS);
            path.Add(Id);

            _request.SetPath(path);
            return _client.SendRequest(_request, GET);
        }

        /// <summary>
        /// Relatorio de envio de TTS
        /// </summary>
        /// <param name="DataInicial">Periodo inicial para a consulta</param>
        /// <param name="DataFinal">Periodo final para a consulta.</param>
        /// <param name="Filtros">Filtros adicionais que podem ser enviados.</param>
        /// 
        public string Relatorio(DateTime DataInicial, DateTime DataFinal, Filter Filtros = null)
        {
            Path path = new Path();
            path.Add(ROTA_TTS);
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

            return _client.SendRequest(_request, GET);
        }
    }
}
