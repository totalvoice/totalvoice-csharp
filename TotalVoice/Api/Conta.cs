using System;

namespace TotalVoice.Api
{
    /// <summary>
    /// Conta class
    /// </summary>
    public class Conta : Api
    {
        public const string ROTA_CONTA = "conta";

        public Conta(IClient client) : base(client) { }
        public Conta(IClient client, IRequest request) : base(client, request) { }

        /// <summary>
        /// Criar uma Conta
        /// </summary>
        /// <param name="Data">Estrutura enviada para o Post.</param>
        /// 
        // Ex: 
        // var Data = new {
        //    nome  = "TotalVoice",
        //    login = "contato@empresa.com",
        //    senha = "senhasupersecreta"
        //    ...
        // };
        /// DOCS:
        /// https://totalvoice.github.io/totalvoice-docs/#gerenciar-contas
        /// 
        public string Criar(dynamic Data)
        {
            Path path = new Path();
            path.Add(ROTA_CONTA);

            _request.SetPath(path);
            _request.SetBody(Data);
            return _client.SendRequest(_request, POST);
        }

        /// <summary>
        /// Atualiza os dados de uma Conta
        /// </summary>
        /// <param name="Id">ID da conta que sera atualizada.</param>
        /// <param name="Data">Estrutura enviada para o Post.</param>
        /// 
        // Ex: 
        // var Data = new {
        //    nome  = "TotalVoice",
        //    login = "contato@empresa.com",
        //    senha = "senhasupersecreta"
        //    ...
        // };
        /// DOCS:
        /// https://totalvoice.github.io/totalvoice-docs/#gerenciar-contas
        /// 
        public string Atualizar(int Id, dynamic Data)
        {
            Path path = new Path();
            path.Add(ROTA_CONTA);
            path.Add(Id);

            _request.SetPath(path);
            _request.SetBody(Data);
            return _client.SendRequest(_request, PUT);
        }

        /// <summary>
        /// Busca uma Conta pelo seu ID
        /// </summary>
        /// <param name="Id">ID da Conta.</param>
        /// 
        public string Buscar(int Id)
        {
            Path path = new Path();
            path.Add(ROTA_CONTA);
            path.Add(Id);

            _request.SetPath(path);
            return _client.SendRequest(_request, GET);
        }

        /// <summary>
        /// Remove uma Conta
        /// </summary>
        /// <param name="Id">Id da Conta</param>
        /// 
        public string Excluir(int Id)
        {
            Path path = new Path();
            path.Add(ROTA_CONTA);
            path.Add(Id);

            _request.SetPath(path);

            return _client.SendRequest(_request, DELETE);
        }

        /// <summary>
        /// Relatorio das Contas criadas
        /// </summary>
        /// <param name="DataInicial">Periodo inicial para a consulta</param>
        /// <param name="DataFinal">Periodo final para a consulta.</param>
        /// <param name="Filtros">Filtros adicionais que podem ser enviados.</param>
        /// 
        public string Relatorio(DateTime DataInicial, DateTime DataFinal, Filter Filtros = null)
        {
            Path path = new Path();
            path.Add(ROTA_CONTA);
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
