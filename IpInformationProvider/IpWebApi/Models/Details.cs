using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpWebApi.Models
{
    public class Details
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Continent { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
