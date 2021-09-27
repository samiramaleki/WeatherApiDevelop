using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using weatherapi.Application.Commands;
using weatherapi.Models;

namespace weatherapi.Application.Handlers
{
    public class CreateCurrentWetherHandler : IRequestHandler<CurentWetherCommand, bool>
    {
        private readonly WhetherContext _context;
        public CreateCurrentWetherHandler(WhetherContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(CurentWetherCommand request, CancellationToken cancellationToken)
        {
            _context.Weathers.Add(new Weather
            {
                City = request.CityName,
                TemperatureC = request.TemperatureC
            });
            return await _context.SaveChangesAsync() > 0;

        }
    }
}
