using IpWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpWebApi.Business
{
    public interface IpBatchBusinessInterface
    {
        public IpRequest CreateRequest(string[] ips);

        public string ReadFile();
    }
}
