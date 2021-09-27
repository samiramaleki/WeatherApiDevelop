using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weatherapi.Application.Commands;
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
        private readonly IWheatherService _wheatherService;
        private readonly IMediator _mediateR;
        public WetherController(IWheatherService wheatherService, IMediator mediator)
        {
            _wheatherService = wheatherService;
            _mediateR = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<CurrentWeatherInformation>> WhetherStatusAsync(string cityName)
        {
            var currentWetherInformation = await _wheatherService.GetAsync(cityName);

            if (currentWetherInformation != null && currentWetherInformation?.current?.Celsius > 14)
                await _mediateR.Send(new CurentWetherCommand
                {
                    CityName = currentWetherInformation.location.Name,
                    TemperatureC = currentWetherInformation.current.Celsius
                });
            return currentWetherInformation;
        }
    }
}
