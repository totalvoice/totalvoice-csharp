using System;

namespace TotalVoice.Api
{
    public class Conferencia : Api
    {
        public const string ROTA_CONFERENCIA = "conferencia";

        public Conferencia(IClient client) : base(client) { }
        public Conferencia(IClient client, IRequest request) : base(client, request) { }

        /// <summary>
        /// Envia um Torpedo Composto para um número destino
        /// </summary>
        /// DOCS:
        /// https://totalvoice.github.io/totalvoice-docs/#conferencias
        ///
        public string Criar()
        {
            Path path = new Path();
            path.Add(ROTA_CONFERENCIA);

            _request.SetPath(path);

            return _client.SendRequest(_request, "POST");
        }

        /// <summary>
        /// Adiciona o numero em uma Conferencia
        /// </summary>
        /// <param name="Id">ID da conferencia.</param> 
        // Ex: 
        // var Data = new {
        //    numero = "48988888888",
        //    gravar_audio = false,
        //    bina = "48988888888"
        // };
        /// DOCS:
        /// https://totalvoice.github.io/totalvoice-docs/#conferencias
        ///
        public string AddNumeroConferencia(int Id, dynamic Data)
        {
            Path path = new Path();
            path.Add(ROTA_CONFERENCIA);
            path.Add(Id);

            _request.SetPath(path);
            _request.SetBody(Data);
            return _client.SendRequest(_request, "POST");
        }

        /// <summary>
        /// Busca um Composto pelo seu ID
        /// </summary>
        /// <param name="Id">ID do Composto.</param>
        /// 
        public string Buscar(int Id)
        {
            Path path = new Path();
            path.Add(ROTA_CONFERENCIA);
            path.Add(Id);

            _request.SetPath(path);
            return _client.SendRequest(_request, "GET");
        }

        /// <summary>
        /// Remove uma conferência ativa
        /// </summary>
        /// <param name="Id">Id da Conferencia</param>
        /// 
        public string Excluir(int Id)
        {
            Path path = new Path();
            path.Add(ROTA_CONFERENCIA);
            path.Add(Id);

            _request.SetPath(path);

            return _client.SendRequest(_request, "DELETE");
        }

        /// <summary>
        /// Relatorio de Conferencia criadas
        /// </summary>
        /// <param name="DataInicial">Periodo inicial para a consulta</param>
        /// <param name="DataFinal">Periodo final para a consulta.</param>
        /// <param name="Filtros">Filtros adicionais que podem ser enviados.</param>
        /// 
        public string Relatorio(DateTime DataInicial, DateTime DataFinal, Filter Filtros = null)
        {
            Path path = new Path();
            path.Add(ROTA_CONFERENCIA);
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

        /// <summary>
        /// Relatorio de chamadas em Conferencia
        /// </summary>
        /// <param name="DataInicial">Periodo inicial para a consulta</param>
        /// <param name="DataFinal">Periodo final para a consulta.</param>
        /// <param name="Filtros">Filtros adicionais que podem ser enviados.</param>
        /// 
        public string RelatorioChamadas(DateTime DataInicial, DateTime DataFinal, Filter Filtros = null)
        {
            Path path = new Path();
            path.Add(ROTA_CONFERENCIA);
            path.Add("chamadas");
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
