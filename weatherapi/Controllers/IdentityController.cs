using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weatherapi.Application.Commands;
using weatherapi.DTOs;

namespace weatherapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IdentityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<bool>> Register([FromBody] CreateUserCommand user)
        {
            return await _mediator.Send(user);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<string>> Authenticate([FromBody] LoginCommand model)
        {
            var user = await _mediator.Send(model);

            if (user == null)
                return NotFound(new { message = "User or password invalid" });
            return user.ToString();
        }

    }
}
