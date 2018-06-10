namespace TotalVoice
{
    public interface IClient
    {
        string Get(IRequest request);

        string Post(IRequest request);

        string Put(IRequest request);

        string Delete(IRequest request);
    }
}
