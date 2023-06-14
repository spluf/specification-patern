using Capon.Users.Domain.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capon.Users.Domain.Contracts.Services
{
    public interface IUserService
    {
        Task RegisterUser(UserVM user);
        Task<UserVM[]> Get();
    }
}
