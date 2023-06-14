using Capon.Users.Application.Services;
using Capon.Users.Domain.Contracts.Repositories;
using Capon.Users.Domain.Contracts.Services;
using Capon.Users.Domain.Models.Data;
using Capon.Users.Manager.CommandHandlers;
using Capon.Users.Persistance.Repositories;
using Capon.Users.Persistance.Sql;
using CapOn.Users.Domain.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Reflection;

namespace Capon.Users.ServiceBuilder
{
    public static class UserServiceBuilder
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            // MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddScoped<IRequestHandler<RegisterUserCommand>, UserCommandHandler>();

            // SQL
            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("UserDbConnectionString"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            // Custom Services
            services.AddScoped<IUserService, UserService>();
            
            // Repositories
            services.AddScoped(typeof(IGenericRepository<User>), typeof(GenericRepository<User>));
        }
    }
}