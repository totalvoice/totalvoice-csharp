namespace TotalVoice
{
    public interface IRequest
    {
        void SetPath(Path path);

        Path GetPath();

        string GetPathString();

        string GetURL();

        void SetQuery(QueryString query);

        QueryString GetQuery();

        string GetQueryString();
    }
}
