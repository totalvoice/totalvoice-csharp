using System;

namespace TotalVoice.Api
{
    public class Composto : Api
    {
        public const string ROTA_COMPOSTO = "composto";

        public Composto(IClient client) : base(client) { }
        public Composto(IClient client, IRequest request) : base(client, request) { }

        /// <summary>
        /// Envia um Torpedo Composto para um número destino
        /// </summary>
        /// <param name="Data">Estrutura enviada para o Post.</param>
        /// 
        // Ex: 
        // var Data = new {
        //    numero_destino = "48988888888",
        //    dados = new[] {
        //       new {
        //         acao = "tts",
        //         acao_dados = new {
        //           mensagem = "O número digitado não consta em nosso cadastro. Por gentileza, tente novamente",
        //           tipo_voz = "br-Ricardo" 
        //         }
        //       },
        //       new {
        //         acao = "audio",
        //         acao_dados = new {
        //           url_audio = "https://minhaurl.com.br/audio.mp3"
        //         }
        //       }
        //    },
        //    gravar_audio     = false,
        //    bina             = "48988888888",
        //    tags             = "clienteX",
        //    detecta_caixa    = false
        // };
        //
        /// DOCS:
        /// https://totalvoice.github.io/totalvoice-docs/#composto
        ///
        public string Enviar(dynamic Data)
        {
            Path path = new Path();
            path.Add(ROTA_COMPOSTO);

            _request.SetPath(path);
            _request.SetBody(Data);
            return _client.SendRequest(_request, POST);
        }

        /// <summary>
        /// Busca um Composto pelo seu ID
        /// </summary>
        /// <param name="Id">ID do Composto.</param>
        /// 
        public string Buscar(int Id)
        {
            Path path = new Path();
            path.Add(ROTA_COMPOSTO);
            path.Add(Id);

            _request.SetPath(path);
            return _client.SendRequest(_request, GET);
        }

        /// <summary>
        /// Relatorio de envio de Composto
        /// </summary>
        /// <param name="DataInicial">Periodo inicial para a consulta</param>
        /// <param name="DataFinal">Periodo final para a consulta.</param>
        /// <param name="Filtros">Filtros adicionais que podem ser enviados.</param>
        /// 
        public string Relatorio(DateTime DataInicial, DateTime DataFinal, Filter Filtros = null)
        {
            Path path = new Path();
            path.Add(ROTA_COMPOSTO);
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
