using System;

namespace TotalVoice.Api
{
    /// <summary>
    /// Perfil Class
    /// DOCS:
    /// https://totalvoice.github.io/totalvoice-docs/#minha-conta
    /// </summary>
    public class Perfil : Api
    {
        public const string ROTA_SALDO = "saldo";
        public const string ROTA_PERFIL = "conta";
        public const string ROTA_WEBHOOK = "webhook";

        public Perfil(IClient client) : base(client) { }
        public Perfil(IClient client, IRequest request) : base(client, request) { }

        /// <summary>
        /// Consulta saldo atual
        /// </summary>
        /// 
        public string ConsultaSaldo()
        {
            Path path = new Path();
            path.Add(ROTA_SALDO);

            _request.SetPath(path);
            return _client.SendRequest(_request, GET);
        }

        /// <summary>
        /// Leitura dos dados da minha conta
        /// </summary>
        /// 
        public string MinhaConta()
        {
            Path path = new Path();
            path.Add(ROTA_PERFIL);

            _request.SetPath(path);
            return _client.SendRequest(_request, GET);
        }

        /// <summary>
        ///  Atualiza os dados da minha conta
        /// </summary>
        /// <param name="Data">Estrutura enviada para o Post.</param>
        /// 
        public string Atualizar(dynamic Data)
        {
            Path path = new Path();
            path.Add(ROTA_PERFIL);

            _request.SetPath(path);
            _request.SetBody(Data);
            return _client.SendRequest(_request, PUT);
        }

        /// <summary>
        /// Relatorio de recargas da Conta
        /// </summary>
        /// 
        public string RelatorioRecarga()
        {
            Path path = new Path();
            path.Add(ROTA_PERFIL);
            path.Add("recargas");

            _request.SetPath(path);
            return _client.SendRequest(_request, GET);
        }

        /// <summary>
        /// Gera uma URL para recarga de créditos
        /// </summary>
        /// <param name="Url">URL de retorno.</param>
        /// 
        public string UrlRecarga(string Url)
        {
            Path path = new Path();
            path.Add(ROTA_PERFIL);
            path.Add("urlrecarga");

            QueryString query = new QueryString();
            query.Add("url_retorno", Url);

            _request.SetPath(path);
            _request.SetQuery(query);

            return _client.SendRequest(_request, GET);
        }

        /// <summary>
        /// Retorna a lista de webhooks configurados para esta conta
        /// </summary>
        /// 
        public string Webhooks()
        {
            Path path = new Path();
            path.Add(ROTA_WEBHOOK);

            _request.SetPath(path);
            return _client.SendRequest(_request, GET);
        }

        /// <summary>
        /// Remove o webhook da sua Conta
        /// </summary>
        /// <param name="Nome">Nome do Webhook</param>
        /// 
        public string ExcluirWebhook(string Nome)
        {
            Path path = new Path();
            path.Add(ROTA_WEBHOOK);
            path.Add(Nome);

            _request.SetPath(path);

            return _client.SendRequest(_request, DELETE);
        }

        /// <summary>
        ///  Atualiza/Cria os dados do Webhook
        /// </summary>
        /// <param name="Nome">Nome do webhook a ser criado ou atualizado.</param>
        /// <param name="Url">URL do Webhook.</param>
        /// 
        public string SalvaWebhook(string Nome, string Url)
        {
            Path path = new Path();
            path.Add(ROTA_WEBHOOK);
            path.Add(Nome);

            _request.SetPath(path);
            _request.SetBody(new { url = Url });

            return _client.SendRequest(_request, PUT);
        }
    }
}
