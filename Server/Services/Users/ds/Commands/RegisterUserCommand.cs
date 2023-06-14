using CapOn.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapOn.Users.Engine.Commands
{
    public class RegisterUserCommand : ICommand
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? County { get; set; }
        public string? Country { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
    }
}
