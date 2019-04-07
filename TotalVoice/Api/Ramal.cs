using System;

namespace TotalVoice.Api
{
    /// <summary>
    /// Ramal Class
    /// DOCS:
    /// https://totalvoice.github.io/totalvoice-docs/#central-telefonica
    /// </summary>
    public class Ramal : Api
    {
        public const string ROTA_RAMAL = "ramal";

        public Ramal(IClient client) : base(client) { }
        public Ramal(IClient client, IRequest request) : base(client, request) { }

        /// <summary>
        /// Criar um Ramal
        /// </summary>
        /// <param name="Data">Estrutura enviada para o Post.</param>
        /// 
        // Ex: 
        // var Data = new {
        //    ramal = "4000",
        //    login = "contato@empresa.com",
        //    senha = "senhasupersecreta"
        //    ...
        // };
        /// 
        public string Criar(dynamic Data)
        {
            Path path = new Path();
            path.Add(ROTA_RAMAL);

            _request.SetPath(path);
            _request.SetBody(Data);
            return _client.SendRequest(_request, POST);
        }

        /// <summary>
        /// Atualiza os dados do Ramal
        /// </summary>
        /// <param name="Id">ID do Ramal.</param>
        /// <param name="Data">Estrutura enviada para o Post.</param>
        /// 
        // Ex: 
        // var Data = new {
        //    ramal = "4000",
        //    login = "contato@empresa.com",
        //    senha = "senhasupersecreta"
        //    ...
        // };
        /// 
        public string Atualizar(int Id, dynamic Data)
        {
            Path path = new Path();
            path.Add(ROTA_RAMAL);
            path.Add(Id);

            _request.SetPath(path);
            _request.SetBody(Data);
            return _client.SendRequest(_request, PUT);
        }

        /// <summary>
        /// Remove um Ramal
        /// </summary>
        /// <param name="Id">Id do Ramal</param>
        /// 
        public string Excluir(int Id)
        {
            Path path = new Path();
            path.Add(ROTA_RAMAL);
            path.Add(Id);

            _request.SetPath(path);

            return _client.SendRequest(_request, DELETE);
        }


        /// <summary>
        /// Busca um Ramal pelo seu ID
        /// </summary>
        /// <param name="Id">ID do Ramal.</param>
        /// 
        public string Buscar(int Id)
        {
            Path path = new Path();
            path.Add(ROTA_RAMAL);
            path.Add(Id);

            _request.SetPath(path);
            return _client.SendRequest(_request, GET);
        }

        /// <summary>
        /// Gera relatório de ramais criados
        /// </summary>
        /// <param name="DataInicial">Periodo inicial para a consulta</param>
        /// <param name="DataFinal">Periodo final para a consulta.</param>
        /// <param name="Filtros">Filtros adicionais que podem ser enviados.</param>
        /// 
        public string Relatorio(DateTime DataInicial, DateTime DataFinal, Filter Filtros = null)
        {
            Path path = new Path();
            path.Add(ROTA_RAMAL);
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
