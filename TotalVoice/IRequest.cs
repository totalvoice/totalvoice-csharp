namespace TotalVoice
{
    public interface IRequest
    {
        void SetPath(Path path);

        string GetPathString();

        string GetURL();

        void SetQuery(QueryString query);

        string GetQueryString();

        void SetBody(string data);

        string GetBody();
    }
}
