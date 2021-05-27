using IIpInformationProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpWebApi.Business
{
    public interface IpBusinessInterface
    {
        public Task<IpDetails> GetIpDetailsAsync(string ip);
    }
}
