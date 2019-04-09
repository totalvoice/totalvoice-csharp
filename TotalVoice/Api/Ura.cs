
namespace TotalVoice.Api
{
    /// <summary>
    /// URA Class
    /// https://totalvoice.github.io/totalvoice-docs/#introducao
    /// </summary>
    public class Ura : Api
    {
        public const string ROTA_URA = "ura";

        public Ura(IClient client) : base(client) { }
        public Ura(IClient client, IRequest request) : base(client, request) { }

        /// <summary>
        /// Criar URA
        /// </summary>
        /// <param name="Nome">Nome da URA.</param>
        /// <param name="Data">Estrutura enviada para o Post.</param>
        /// 
        public string Criar(string Nome, dynamic Data)
        {
            Path path = new Path();
            path.Add(ROTA_URA);

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
        public string Atualizar(int Id, dynamic Data)
        {
            Path path = new Path();
            path.Add(ROTA_URA);
            path.Add(Id);

            _request.SetPath(path);
            _request.SetBody(Data);
            return _client.SendRequest(_request, PUT);
        }

        /// <summary>
        /// Remove uma Ura
        /// </summary>
        /// <param name="Id">Id da Conta</param>
        /// 
        public string Excluir(int Id)
        {
            Path path = new Path();
            path.Add(ROTA_URA);
            path.Add(Id);

            _request.SetPath(path);

            return _client.SendRequest(_request, DELETE);
        }
    }
}
