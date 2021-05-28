using System;
using System.IO;
using System.Linq;
using IpWebApi.Models;
using System.Collections.Generic;

namespace IpWebApi.Business
{
    public class IpBatchBusiness : IIpBatchBusinessInterface
    {
        public IpRequest CreateRequest(string[] ips)
        {
            IpRequest ipRequest = new IpRequest();
            ipRequest.guid = Guid.NewGuid();

            Dictionary<string, Status> ipStatus = new Dictionary<string, Status>();
            
            for (int i = 0; i < ips.Count(); i++)
            {
                ipStatus.Add(ips[i], new Status {
                    //Todo = true,
                    Processed = false
                });
            }

            ipRequest.IpStatus = ipStatus;

            return ipRequest;
        }

        public string ReadFile()
        {
            TextReader tr = new StreamReader(@"IpList.txt");
            return tr.ReadLine();
        }
    }
}
