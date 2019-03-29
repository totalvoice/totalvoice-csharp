using Newtonsoft.Json;

namespace TotalVoice
{
    public class Request : IRequest
    {
        Path Path;
        QueryString Query;
        string Body;

        public Request() {}
        
        public string GetPathString()
        {
            if (Path == null)
            {
                return "";
            }
            return Path.GetPathString();
        }
        
        public string GetQueryString()
        {
            if (Query == null || Query.IsEmpty())
            {
                return "";
            }
            return Query.Build();
        }

        public string GetURL()
        {
            return (GetPathString() + GetQueryString()).Trim();
        }

        public string GetBody()
        {
            return Body;
        }

        public void SetPath(Path path) => Path = path;

        public void SetQuery(QueryString query) => Query = query;

        public void SetBody(dynamic data)
        {
            Body = JsonConvert.SerializeObject(data);
        }
    }
}
