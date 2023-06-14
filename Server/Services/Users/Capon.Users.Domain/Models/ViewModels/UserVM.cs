using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capon.Users.Domain.Models.ViewModels
{
    public class UserVM
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public AddressVm? Address { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
    }
}
