using Capon.Users.Domain.Contracts.Repositories;
using Capon.Users.Domain.Contracts.Specifications;
using Capon.Users.Domain.Specifications;
using Capon.Users.Persistance.Sql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capon.Users.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly UserDbContext context;

        public GenericRepository(UserDbContext context)
        {
            this.context = context;
        }

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        public async Task<IEnumerable<T>> FindFromSpecificationAsync(ISpecification<T> specification = null)
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        {
            return await SpecificationEvaluator<T>.Evaluate(context.Set<T>().AsQueryable(), specification);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await context.Set<T>().FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.
        }


        public async Task AddAsync(T entity)
        {
            try
            {
                context.Set<T>().Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            { 

                throw;
            }
        }


        public async Task UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await context.Set<T>().FindAsync(id);

            if(entity!= null) 
            {
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
