
using System;

namespace TotalVoice.Api
{
    /// <summary>
    /// Fila Class
    /// DOCS:
    /// https://totalvoice.github.io/totalvoice-docs/#introducao
    /// </summary>
    public class Fila : Api
    {
        public const string ROTA_FILA = "fila";

        public Fila(IClient client) : base(client) { }
        public Fila(IClient client, IRequest request) : base(client, request) { }

        /// <summary>
        /// Cria um Fila de Atendimento
        /// </summary>
        /// <param name="Data">Estrutura enviada para o Post.</param>
        /// 
        // Ex: 
        // var Data = new {
        //    nome            = "Nome da fila",
        //    estrategia_ring = "Distribuidor",
        //    timeout_ring    = "20"
        // };
        ///
        public string Criar(dynamic Data)
        {
            Path path = new Path();
            path.Add(ROTA_FILA);

            _request.SetPath(path);
            _request.SetBody(Data);
            return _client.SendRequest(_request, POST);
        }

        /// <summary>
        /// Adiciona um ramal na fila
        /// </summary>
        /// <param name="Id">ID da Fila.</param>
        /// <param name="RamalId">ID do Ramal.</param>
        /// 
        public string AdicionaRamal(int Id, int RamalId)
        {
            Path path = new Path();
            path.Add(ROTA_FILA);
            path.Add(Id);

            _request.SetPath(path);
            _request.SetBody(new { ramal_id = RamalId });
            return _client.SendRequest(_request, POST);
        }

        /// <summary>
        /// Busca as informações da Fila de Atendimento
        /// </summary>
        /// <param name="Id">ID da Fila.</param>
        /// 
        public string Buscar(int Id)
        {
            Path path = new Path();
            path.Add(ROTA_FILA);
            path.Add(Id);

            _request.SetPath(path);
            return _client.SendRequest(_request, GET);
        }

        /// <summary>
        /// Busca as informações de um ramal da Fila de Atendimento
        /// </summary>
        /// <param name="Id">ID da Fila.</param>
        /// <param name="RamalId">ID do Ramal.</param>
        /// 
        public string BuscarRamal(int Id, int RamalId)
        {
            Path path = new Path();
            path.Add(ROTA_FILA);
            path.Add(Id);
            path.Add(RamalId);

            _request.SetPath(path);
            return _client.SendRequest(_request, GET);
        }

        /// <summary>
        /// Atualiza as informações da fila
        /// </summary>
        /// <param name="Id">ID da conta que sera atualizada.</param>
        /// <param name="Data">Estrutura enviada para o Post.</param>
        /// 
        // Ex: 
        // var Data = new {
        //    nome            = "Nome da fila",
        //    estrategia_ring = "Distribuidor",
        //    timeout_ring    = "20"
        // };
        /// 
        public string Atualizar(int Id, dynamic Data)
        {
            Path path = new Path();
            path.Add(ROTA_FILA);
            path.Add(Id);

            _request.SetPath(path);
            _request.SetBody(Data);
            return _client.SendRequest(_request, PUT);
        }

        /// <summary>
        /// Remove um ramal da fila
        /// </summary>
        /// <param name="Id">Id da Fila</param>
        /// <param name="RamalId">ID do Ramal.</param>
        /// 
        public string ExcluirRamal(int Id, int RamalId)
        {
            Path path = new Path();
            path.Add(ROTA_FILA);
            path.Add(Id);
            path.Add(RamalId);

            _request.SetPath(path);

            return _client.SendRequest(_request, DELETE);
        }

        /// <summary>
        /// Relatorio de chamadas recebidas na Fila
        /// </summary>
        /// <param name="Id">Id da Fila</param>
        /// <param name="DataInicial">Periodo inicial para a consulta</param>
        /// <param name="DataFinal">Periodo final para a consulta.</param>
        /// <param name="Filtros">Filtros adicionais que podem ser enviados.</param>
        /// 
        public string Relatorio(int Id, DateTime DataInicial, DateTime DataFinal, Filter Filtros = null)
        {
            Path path = new Path();
            path.Add(ROTA_FILA);
            path.Add(Id);
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
