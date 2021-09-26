using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using weatherapi.Application.Commands;
using weatherapi.Models;
using weatherapi.Services;

namespace weatherapi.Application.Handlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly WhetherContext _context;
        public LoginHandler(WhetherContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.UserName == request.UserName && user.PassWord == request.PassWord);
            if (user == null)
                return null;

            return TokenService.CreateToken(user);
        }
    }
}
