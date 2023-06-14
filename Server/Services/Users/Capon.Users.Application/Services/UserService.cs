using Capon.Users.Domain.Contracts.Services;
using Capon.Users.Domain.Models.Data;
using Capon.Users.Domain.Models.ViewModels;
using Capon.Users.Domain.Queries;
using CapOn.Users.Domain.Commands;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capon.Users.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMediator mediator;

        public UserService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task RegisterUser(UserVM user)
        {
            var command = new RegisterUserCommand(user.Adapt<User>());

            await mediator.Send(command);
        }

        public async Task<UserVM[]> Get()
        {
            var query = new GetAllUsersQuery();

            var result = await mediator.Send<User[]>(query);

            return result.AsQueryable().ProjectToType<UserVM>().ToArray();
        }
    }
}
