using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weatherapi.DTOs;

namespace weatherapi.Services
{
    public interface IWheatherService
    {
        Task<CurrentWeatherInformation> GetAsync(string cityName);
    }
}
