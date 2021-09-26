using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weatherapi.Application.Commands
{
    public class LoginCommand : IRequest<string>
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
