using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capon.Users.Domain.Models.ViewModels
{
    public class AddressVm
    {
        public Guid Id { get; set; }
        public string? StreetName { get; set; }
        public string? StreetNumber { get; set; }
        public string? Building { get; set; }
        public string? Appartment { get; set; }
        public string? City { get; set; }
        public string? County { get; set; }
        public string? Country { get; set; }
        public bool IsMain { get; set; }
    }
}
