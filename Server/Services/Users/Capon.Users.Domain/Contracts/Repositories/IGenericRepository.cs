
using Capon.Users.Domain.Contracts.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capon.Users.Domain.Contracts.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        Task<IEnumerable<T>> FindFromSpecificationAsync(ISpecification<T> specification = null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }
}
