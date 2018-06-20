namespace TotalVoice
{
    public interface IClient
    {
        string SendRequest(IRequest request, string method);
    }
}
