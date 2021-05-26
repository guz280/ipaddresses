using System;
using System.Collections.Generic;
using System.Text;

namespace IIpInformationProvider
{
    public class IPDetailsResponseModel
    {
        public string city { get; set; }
        public string country_name { get; set; }
        public string continent_name { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }

    }
}
