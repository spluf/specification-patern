using Capon.Users.Domain.Contracts.Repositories;
using Capon.Users.Domain.Models.Data;
using Capon.Users.Domain.Queries;
using Capon.Users.Domain.Specifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capon.Users.Manager.QueryHandlers
{
    public class UserQueryHandler : IRequestHandler<GetAllUsersQuery, User[]>
    {
        private readonly IGenericRepository<User> _repository;
        public UserQueryHandler(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<User[]> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.FindFromSpecificationAsync(new GetAllUsersSpecification());
            return result.ToArray();
        }
    }
}
