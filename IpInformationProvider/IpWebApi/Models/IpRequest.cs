using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpWebApi.Models
{
    public class IpRequest
    {
        public Guid guid { get; set; }

        public IDictionary<string, Status> IpStatus { get; set; }
    }

    public class Status
    {
        //public bool Todo { get; set; }
        public bool Processed { get; set; }
    }
}