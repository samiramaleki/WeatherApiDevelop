using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weatherapi.Models
{
    public class Weather
    {
        public int Id { get; set; }
        public string City { get; set; }
        public float TemperatureC { get; set; }
    }
}
