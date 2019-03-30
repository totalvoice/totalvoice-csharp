using Newtonsoft.Json;

namespace TotalVoice
{
    public class Request : IRequest
    {
        Path _path;
        QueryString _query;
        string _body;

        public Request() {}
        
        public string GetPathString()
        {
            if (_path == null)
            {
                return "";
            }
            return _path.GetPathString();
        }
        
        public string GetQueryString()
        {
            if (_query == null || _query.IsEmpty())
            {
                return "";
            }
            return _query.Build();
        }

        public string GetURL()
        {
            return (GetPathString() + GetQueryString()).Trim();
        }

        public string GetBody()
        {
            return _body;
        }

        public void SetPath(Path path) => _path = path;

        public void SetQuery(QueryString query) => _query = query;

        public void SetBody(dynamic data)
        {
            _body = JsonConvert.SerializeObject(data);
        }
    }
}
