using System;

namespace TotalVoice.Api
{
    public class Chamada : Api
    {
        public const string ROTA_CHAMADA = "chamada";

        public Chamada(IClient client) : base(client) { }
        public Chamada(IClient client, IRequest request) : base(client, request) { }

        /// <summary>
        /// Realiza uma chamada telefônica entre dois números: A e B
        /// </summary>
        /// <param name="Data">Estrutura enviada para o Post.</param>
        /// 
        // Ex: 
        // var Data = new {
        //    numero_origem = "48988888888",
        //    numero_destino= "48988888888",
        //    data_criacao  = "2017-03-30T17:17:14-03:00",
        //    gravar_audio  = false,
        //    bina_origem   = "48988888888",
        //    bina_destino  = "48988888888",
        //    tags          = "clienteX"
        // };
        /// DOCS:
        /// https://totalvoice.github.io/totalvoice-docs/#chamadas
        ///
        public string Ligar(dynamic Data)
        {
            Path path = new Path();
            path.Add(ROTA_CHAMADA);

            _request.SetPath(path);
            _request.SetBody(Data);
            return _client.SendRequest(_request, "POST");
        }

        /// <summary>
        /// Encerra uma chamada ativa
        /// </summary>
        /// <param name="Id">Id da chamada que sera encerrada</param>
        /// 
        public string Encerrar(int Id)
        {
            Path path = new Path();
            path.Add(ROTA_CHAMADA);
            path.Add(Id);

            _request.SetPath(path);

            return _client.SendRequest(_request, "DELETE");
        }

        /// <summary>
        /// Busca as informações do registro da chamada
        /// </summary>
        /// <param name="Id">ID do Chamada.</param>
        /// 
        public string Buscar(int Id)
        {
            Path path = new Path();
            path.Add(ROTA_CHAMADA);
            path.Add(Id);

            _request.SetPath(path);
            return _client.SendRequest(_request, "GET");
        }

        /// <summary>
        /// URL para download do audio
        /// </summary>
        /// <param name="Id">ID do Chamada.</param>
        /// 
        public string DownloadGravacao(int Id)
        {
            Path path = new Path();
            path.Add(ROTA_CHAMADA);
            path.Add(Id);
            path.Add("gravacao");

            _request.SetPath(path);
            return _client.SendRequest(_request, "GET");
        }

        /// <summary>
        /// Relatorio de chamadas efetuadas
        /// </summary>
        /// <param name="DataInicial">Periodo inicial para a consulta</param>
        /// <param name="DataFinal">Periodo final para a consulta.</param>
        /// <param name="Filtros">Filtros adicionais que podem ser enviados.</param>
        /// 
        public string Relatorio(DateTime DataInicial, DateTime DataFinal, Filter Filtros = null)
        {
            Path path = new Path();
            path.Add(ROTA_CHAMADA);
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

            return _client.SendRequest(_request, "GET");
        }

        /// <summary>
        /// (Beta) Escuta uma chamada ativa
        /// </summary>
        /// <param name="Id">ID da chamada que sera escutada.</param>
        /// <param name="Numero">Numero do seu telefone.</param>
        /// <param name="Modo">Modo de escuta.</param> 
        /// 
        public string Escutar(int Id, string Numero, int Modo)
        {
            Path path = new Path();
            path.Add(ROTA_CHAMADA);
            path.Add(Id);
            path.Add("escuta");

            _request.SetPath(path);
            _request.SetBody(new { numero = Numero, modo = Modo });

            return _client.SendRequest(_request, "POST");
        }

        /// <summary>
        /// (Beta) Faz uma transferência da chamada atual
        /// </summary>
        /// <param name="Id">ID da chamada que sera transferida.</param>
        /// <param name="Numero">Número ao qual a chamada será transferida.</param>
        /// <param name="Perna">Qual perna da chamada será transferida.</param> 
        /// 
        public string Transferir(int Id, string Numero, string Perna)
        {
            Path path = new Path();
            path.Add(ROTA_CHAMADA);
            path.Add(Id);
            path.Add("transfer");

            _request.SetPath(path);
            _request.SetBody(new { numero = Numero, perna = Perna });

            return _client.SendRequest(_request, "POST");
        }

        /// <summary>
        /// Avalia uma Chamada com nota de 1 a 5
        /// </summary>
        /// <param name="Id">ID da chamada.</param>
        /// <param name="Nota">Nota de 1 a 5.</param>
        /// <param name="Comentario">Texto de até 1000 caracteres.</param> 
        /// 
        public string Avaliar(int Id, string Nota, string Comentario = null)
        {
            Path path = new Path();
            path.Add(ROTA_CHAMADA);
            path.Add(Id);
            path.Add("avaliar");

            _request.SetPath(path);
            _request.SetBody(new { nota = Nota, comentario = Comentario });

            return _client.SendRequest(_request, "POST");
        }
    }
}
