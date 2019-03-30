using System;

namespace TotalVoice.Api
{
    /// <summary>
    /// Audio Class
    /// </summary>
    public class Audio : Api
    {
        public const string ROTA_AUDIO = "audio";

        public Audio(IClient client) : base(client) { }
        public Audio(IClient client, IRequest request) : base(client, request) { }        

        /// <summary>
        /// Envia um audio para um número destino
        /// </summary>
        /// <param name="Data">Estrutura enviada para o Post.</param>
        /// 
        // Ex: 
        // var Data = new {
        //    numero_destino   = "48988888888",
        //    url_audio        = "http://foooo.bar/audio.mp3",
        //    resposta_usuario = false,
        //    gravar_audio     = false,
        //    bina             = "48988888888",
        //    detecta_caixa    = false
        // };
        /// 
        public string Enviar(dynamic Data)
        {
            Path path = new Path();
            path.Add(ROTA_AUDIO);

            _request.SetPath(path);
            _request.SetBody(Data);
            return _client.SendRequest(_request, "POST");
        }

        /// <summary>
        /// Busca um Audio pelo seu ID
        /// </summary>
        /// <param name="Id">ID do TTS.</param>
        /// 
        public string Buscar(int Id)
        {
            Path path = new Path();
            path.Add(ROTA_AUDIO);
            path.Add(Id);

            _request.SetPath(path);
            return _client.SendRequest(_request, "GET");
        }

        /// <summary>
        /// Relatorio de envio de Audio
        /// </summary>
        /// <param name="DataInicial">Periodo inicial para a consulta</param>
        /// <param name="DataFinal">Periodo final para a consulta.</param>
        /// <param name="Filtros">Filtros adicionais que podem ser enviados.</param>
        /// 
        public string Relatorio(DateTime DataInicial, DateTime DataFinal, Filter Filtros = null)
        {
            Path path = new Path();
            path.Add(ROTA_AUDIO);
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
