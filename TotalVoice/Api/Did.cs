using System;
using System.Collections.Generic;
using System.Text;

namespace TotalVoice.Api
{
    /// <summary>
    /// DID class
    /// DOCS:
    /// https://totalvoice.github.io/totalvoice-docs/#dids
    /// </summary>
    public class Did : Api
    {
        public const string ROTA_DID = "did";
        public const string ROTA_DID_ESTOQUE = "conferencia";
        public const string ROTA_DID_CHAMADA = "conferencia";

        public Did(IClient client) : base(client) { }
        public Did(IClient client, IRequest request) : base(client, request) { }

        /// <summary>
        /// Lista todos os dids pertencentes
        /// </summary>
        /// 
        public string Listar()
        {
            Path path = new Path();
            path.Add(ROTA_DID);

            _request.SetPath(path);
            return _client.SendRequest(_request, GET);
        }

        /// <summary>
        /// Remove o DID da sua Conta
        /// </summary>
        /// <param name="Id">Id do DID</param>
        /// 
        public string Excluir(int Id)
        {
            Path path = new Path();
            path.Add(ROTA_DID);
            path.Add(Id);

            _request.SetPath(path);

            return _client.SendRequest(_request, DELETE);
        }

        /// <summary>
        /// Atualiza um DID
        /// </summary>
        ///
        public string Atualizar(int Id, int RamalId, int UraId)
        {
            Path path = new Path();
            path.Add(ROTA_DID);
            path.Add(Id);

            _request.SetPath(path);
            _request.SetBody(new { ramal_id = RamalId, ura_id = UraId });

            return _client.SendRequest(_request, PUT);
        }

        /// <summary>
        /// Lista todos os dids disponiveis
        /// </summary>
        /// 
        public string ListarEstoque()
        {
            Path path = new Path();
            path.Add(ROTA_DID);
            path.Add("estoque");

            _request.SetPath(path);
            return _client.SendRequest(_request, GET);
        }

        /// <summary>
        /// Adquirir um DID
        /// </summary>
        ///
        public string Adquirir(int Id)
        {
            Path path = new Path();
            path.Add(ROTA_DID);
            path.Add("estoque");
            path.Add(Id);

            _request.SetPath(path);

            return _client.SendRequest(_request, POST);
        }

        /// <summary>
        /// Busca por uma chamada recebida no DID
        /// </summary>
        /// <param name="Id">ID da Conta.</param>
        /// 
        public string BuscaChamadaRecebida(int Id)
        {
            Path path = new Path();
            path.Add(ROTA_DID);
            path.Add("chamada");
            path.Add(Id);

            _request.SetPath(path);
            return _client.SendRequest(_request, GET);
        }

        /// <summary>
        /// Gera relatório de chamadas recebidas pelo DID
        /// </summary>
        /// <param name="DataInicial">Periodo inicial para a consulta</param>
        /// <param name="DataFinal">Periodo final para a consulta.</param>
        /// <param name="Filtros">Filtros adicionais que podem ser enviados.</param>
        /// 
        public string Relatorio(DateTime DataInicial, DateTime DataFinal, Filter Filtros = null)
        {
            Path path = new Path();
            path.Add(ROTA_DID);
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
