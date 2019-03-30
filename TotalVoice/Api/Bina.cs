
namespace TotalVoice.Api
{
    public class Bina : Api
    {
        public const string ROTA_BINA = "bina";

        public Bina(IClient client) : base(client) { }
        public Bina(IClient client, IRequest request) : base(client, request) { }

        /// <summary>
        /// Envia um número pra receber um código de validação
        /// </summary>
        /// <param name="Telefone">Numero que sera validado</param>
        /// 
        public string Enviar(string Telefone)
        {
            Path path = new Path();
            path.Add(ROTA_BINA);

            _request.SetPath(path);
            _request.SetBody(new { telefone = Telefone });
            return _client.SendRequest(_request, "POST");
        }

        /// <summary>
        /// Verifica se o código é válido para o telefone
        /// </summary>
        /// <param name="Codigo">Codigo que sera validado</param>
        /// <param name="Telefone">Telefone que sera validado</param>
        /// 
        public string Validar(string Codigo, string Telefone)
        {
            Path path = new Path();
            path.Add(ROTA_BINA);

            QueryString query = new QueryString();
            query.Add("codigo", Codigo);
            query.Add("telefone", Telefone);

            _request.SetPath(path);
            _request.SetQuery(query);

            return _client.SendRequest(_request, "GET");
        }

        /// <summary>
        /// Remove o telefone cadastrado na sua Conta
        /// </summary>
        /// <param name="Telefone">Numero que sera removido</param>
        /// 
        public string Excluir(string Telefone)
        {
            Path path = new Path();
            path.Add(ROTA_BINA);
            path.Add(Telefone);

            _request.SetPath(path);

            return _client.SendRequest(_request, "DELETE");
        }

        /// <summary>
        /// Gera relatório com os números cadastrados
        /// </summary>
        /// 
        public string Relatorio()
        {
            Path path = new Path();
            path.Add(ROTA_BINA);
            path.Add("relatorio");

            _request.SetPath(path);

            return _client.SendRequest(_request, "GET");
        }
    }
}
