﻿using System.ComponentModel.DataAnnotations;

namespace IpWebApi.Models
{
    public class Details
    {
        [Key]
        public string Ip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Continent { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
