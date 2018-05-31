namespace TotalVoice
{
    public class Request : IRequest
    {
        private Path Path;
        private QueryString Query;
        private IParameters Parameters;

        public Request() {}
        public Request(IParameters parameters) => Parameters = parameters;
        
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

        public string GetData()
        {
            return Parameters.Serialize();
        }

        public void SetPath(Path path) => Path = path;

        public void SetQuery(QueryString query) => Query = query;
    }
}
