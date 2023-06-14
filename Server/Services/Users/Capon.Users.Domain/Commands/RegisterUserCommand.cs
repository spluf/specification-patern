using Capon.Users.Domain.Models.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapOn.Users.Domain.Commands
{
    public class RegisterUserCommand : IRequest
    {
        public User User { get; set; }

        public RegisterUserCommand(User user)
        {
            User = user;
        }
    }
}
