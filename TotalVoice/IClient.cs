namespace TotalVoice
{
    public interface IClient
    {
        string Get(IRequest request);

        void Post();

        void Put();

        void Delete();
    }
}
