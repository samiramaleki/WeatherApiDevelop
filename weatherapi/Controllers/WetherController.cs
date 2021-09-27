using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weatherapi.DTOs;
using weatherapi.Services;
using static weatherapi.Services.Bootstrapper;

namespace weatherapi.Controllers
{
    [ApiController]
    [Route("api/wether")]
    [Authorize]
    public class WetherController : ControllerBase
    {

        public WetherController()
        {

        }

        [HttpGet]
        public async Task<ActionResult<CurrentWeatherInformation>> WhetherStatus(string cityName)
        {
            var wheatherService = ServiceLocator.GetRequiredService<WheatherService>();
            return await wheatherService.GetAsync(cityName);
        }


    }
}
