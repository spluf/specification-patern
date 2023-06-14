using Capon.Users.Domain.Contracts.Repositories;
using Capon.Users.Domain.Models.Data;
using CapOn.Users.Domain.Commands;
using MediatR;
using Newtonsoft.Json;

namespace Capon.Users.Manager.CommandHandlers
{
    public class UserCommandHandler :
        IRequestHandler<RegisterUserCommand>
    {
        private readonly IGenericRepository<User> _repository;
        public UserCommandHandler(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            User user = request.User != null ? (request.User as User) : null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (user!= null)
            {
                await _repository.AddAsync(user);
            }  
        }
    }
}