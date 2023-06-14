using Capon.Users.Domain.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capon.Users.Domain.Specifications
{
    public class GetAllUsersSpecification : BaseSpecification<User>
    {
        public GetAllUsersSpecification()
        {
            Include(u => u.Address);
        }
    }
}
