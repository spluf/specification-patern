using CapOn.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapOn.Users.Engine.Events
{
    public class UserRegisteredEvent : IEvent
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? County { get; set; }
        public string? Country { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public int Version { get; set; }
        public string Type { get; private set; }

        public UserRegisteredEvent()
        {
            Type = nameof(UserRegisteredEvent);
        }
    }
}
