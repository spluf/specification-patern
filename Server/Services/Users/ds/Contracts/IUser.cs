using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapOn.Users.Engine.Contracts
{
    public interface IUser
    {
        Guid Id { get; }
        string? FirstName { get; set; }
        string? LastName { get; set; }
        string? Address { get; set; }
        string? City { get; set; }
        string? County { get; set; }
        string? Country { get; set; }
        string? PhoneNo { get; set; }
        string? Email { get; set; }
    }
}
