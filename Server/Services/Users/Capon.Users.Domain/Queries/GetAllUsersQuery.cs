using Capon.Users.Domain.Models.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capon.Users.Domain.Queries
{
    public class GetAllUsersQuery : IRequest<User[]>
    {
    }
}
