
namespace TotalVoice.Api
{
    /// <summary>
    /// Verificacao Class
    /// https://totalvoice.github.io/totalvoice-docs/#verificacao
    /// </summary>
    public class Verificacao : Api
    {
        public const string ROTA_VERIFICACAO = "verificacao";

        public Verificacao(IClient client) : base(client) { }
        public Verificacao(IClient client, IRequest request) : base(client, request) { }

        /// <summary>
        /// Envia o código de verificação para o número destino
        /// </summary>
        /// <param name="Data">Estrutura enviada para o Post.</param>
        /// 
        // Ex: 
        // var Data = new {
        //    numero_destino = "48988888888",
        //    nome_produto   = "Meu teste",
        //    tamanho        = 4,
        //    tts            = false
        // };
        /// 
        public string Enviar(dynamic Data)
        {
            Path path = new Path();
            path.Add(ROTA_VERIFICACAO);

            _request.SetPath(path);
            _request.SetBody(Data);
            return _client.SendRequest(_request, POST);
        }

        /// <summary>
        /// Busca os dados da verificacao
        /// </summary>
        /// <param name="Id">ID</param>
        /// <param name="Pin">PIN validado.</param>
        /// 
        public string Buscar(int Id, string Pin)
        {
            Path path = new Path();
            path.Add(ROTA_VERIFICACAO);

            QueryString query = new QueryString();
            query.Add("id", Id);
            query.Add("pin", Pin);

            _request.SetPath(path);
            _request.SetQuery(query);

            return _client.SendRequest(_request, GET);
        }
    }
}
