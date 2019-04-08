using System;

namespace TotalVoice.Api
{
    /// <summary>
    /// ValidaNumero Class
    /// https://totalvoice.github.io/totalvoice-docs/#valida-numero
    /// </summary>
    public class ValidaNumero : Api
    {
        public const string ROTA_VALIDA_NUMERO = "valida_numero";

        public ValidaNumero(IClient client) : base(client) { }
        public ValidaNumero(IClient client, IRequest request) : base(client, request) { }

        /// <summary>
        /// Envia o código de verificação para o número destino
        /// </summary>
        /// <param name="Data">Estrutura enviada para o Post.</param>
        /// 
        // Ex: 
        // var Data = new {
        //    numero_destino = "48988888888",
        //    gravar_audio   = true,
        //    bina           = 48808880804,
        //    max_tentativas = 1
        // };
        /// 
        public string Enviar(dynamic Data)
        {
            Path path = new Path();
            path.Add(ROTA_VALIDA_NUMERO);

            _request.SetPath(path);
            _request.SetBody(Data);
            return _client.SendRequest(_request, POST);
        }

        /// <summary>
        /// Busca os dados da validação
        /// </summary>
        /// <param name="Id">ID</param>
        /// 
        public string Buscar(int Id)
        {
            Path path = new Path();
            path.Add(ROTA_VALIDA_NUMERO);

            QueryString query = new QueryString();
            query.Add("id", Id);

            _request.SetPath(path);
            _request.SetQuery(query);

            return _client.SendRequest(_request, GET);
        }

        /// <summary>
        /// Relatório de numeros validados
        /// </summary>
        /// <param name="DataInicial">Periodo inicial para a consulta</param>
        /// <param name="DataFinal">Periodo final para a consulta.</param>
        /// <param name="Filtros">Filtros adicionais que podem ser enviados.</param>
        /// 
        public string Relatorio(DateTime DataInicial, DateTime DataFinal, Filter Filtros = null)
        {
            Path path = new Path();
            path.Add(ROTA_VALIDA_NUMERO);
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
