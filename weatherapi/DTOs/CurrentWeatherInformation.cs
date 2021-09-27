using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weatherapi.Models;

namespace weatherapi.DTOs
{
    public class CurrentWeatherInformation
    {
        public Location location { get; init; }
        public CurrentWeather current { get; init; }
    }
}
