using IIpInformationProvider;
using System.Threading.Tasks;

namespace IpWebApi.Business
{
    public interface IIpBusinessInterface
    {
        public Task<IpDetails> GetIpDetailsAsync(string ip);
    }
}
