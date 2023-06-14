using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capon.Users.Domain.Models.Data
{
    public class Address
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
