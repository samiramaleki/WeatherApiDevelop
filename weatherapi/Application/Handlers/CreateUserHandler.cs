using DataAccess.Models;
using MediatR;
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
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly WhetherContext _context;
        public CreateUserHandler(WhetherContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PassWord = request.PassWord,
                UserName = request.UserName
            };
            _context.Add(user);
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
