﻿namespace TotalVoice
{
    public class Request : IRequest
    {
        private Path Path;
        private QueryString Query;

        public Path GetPath()
        {
            return Path;
        }

        public string GetPathString()
        {
            if (Path == null)
            {
                return "";
            }
            return Path.GetPathString();
        }

        public QueryString GetQuery()
        {
            return Query;
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

        public void SetPath(Path path) => this.Path = path;

        public void SetQuery(QueryString query) => Query = query;
    }
}
