using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capon.Users.Domain.Models.Data
{
    public class User
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }

        public Guid AddressId { get; set; }
        public Address Address { get; set; }

    }
}
