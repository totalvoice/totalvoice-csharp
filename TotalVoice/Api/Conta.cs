using System;

namespace TotalVoice.Api
{
    /// <summary>
    /// Conta class
    /// </summary>
    public class Conta : Api
    {
        public const string ROTA_CONTA = "conta";
        public const string ROTA_WEBHOOK_DEFAULT = "webhook-default";

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

        /// <summary>
        /// Credita valor de bônus em uma conta filha
        /// </summary>
        /// <param name="Id">Id da conta</param>
        /// <param name="Data">Estrutura enviada para o Post.</param>
        /// 
        public string RecargaBonus(int Id, dynamic Data)
        {
            Path path = new Path();
            path.Add(ROTA_CONTA);
            path.Add(Id);
            path.Add("bonus");

            _request.SetPath(path);
            _request.SetBody(Data);
            return _client.SendRequest(_request, POST);
        }

        /// <summary>
        /// Retorna a lista de webhooks default configurados para esta conta
        /// </summary>
        /// 
        public string WebhooksDefault()
        {
            Path path = new Path();
            path.Add(ROTA_CONTA);
            path.Add(ROTA_WEBHOOK_DEFAULT);

            _request.SetPath(path);
            return _client.SendRequest(_request, GET);
        }

        /// <summary>
        /// Remove o webhook default da sua Conta
        /// </summary>
        /// <param name="Nome">Nome do Webhook</param>
        /// 
        public string ExcluirWebhookDefault(string Nome)
        {
            Path path = new Path();
            path.Add(ROTA_CONTA);
            path.Add(ROTA_WEBHOOK_DEFAULT);
            path.Add(Nome);

            _request.SetPath(path);

            return _client.SendRequest(_request, DELETE);
        }

        /// <summary>
        ///  Atualiza/Cria os dados do Webhook default
        /// </summary>
        /// <param name="Nome">Nome do webhook a ser criado ou atualizado.</param>
        /// <param name="Url">URL do Webhook.</param>
        /// 
        public string SalvarWebhookDefault(string Nome, string Url)
        {
            Path path = new Path();
            path.Add(ROTA_CONTA);
            path.Add(ROTA_WEBHOOK_DEFAULT);
            path.Add(Nome);

            _request.SetPath(path);
            _request.SetBody(new { url = Url });

            return _client.SendRequest(_request, PUT);
        }
    }
}
