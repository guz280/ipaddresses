using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IIpInformationProvider
{
    public interface IIpInfoProviderInterface
    {
        Task<IpDetails> GetDetails(string ip);
    }
}
