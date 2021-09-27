using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weatherapi.Application.Commands
{
    public class CurentWetherCommand : IRequest<bool>
    {
        public string CityName { get; set; }
        public float TemperatureC { get; set; }
    }
}
