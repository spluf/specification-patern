using Capon.Users.Domain.Contracts.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capon.Users.Persistance
{
    public class SpecificationEvaluator<T> where T : class
    {
        public static async Task<IEnumerable<T>> Evaluate(IQueryable<T> query, ISpecification<T> specification)
        {
            if(specification == null)
            {
                return query;
            }

            if(specification.Criteria != null)
            {
                query= query.Where(specification.Criteria);
            }

            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            query = specification.IncludeStrings.Aggregate(query, (current, include) => current.Include(include));

            if(specification.OrderBy!= null)
            {
                query = query.OrderBy(specification.OrderBy);
            }

            if(specification.OrderByDescending!= null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            if(specification.GroupBy!= null)
            {
                query = query.GroupBy(specification.GroupBy).SelectMany(x => x);
            }

            if(specification.IsPaged)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }

            return await query.ToListAsync();
        }
    }
}
