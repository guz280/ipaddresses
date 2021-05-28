using IpWebApi.Models;

namespace IpWebApi.Business
{
    public interface IIpBatchBusinessInterface
    {
        public IpRequest CreateRequest(string[] ips);

        public string ReadFile();
    }
}
