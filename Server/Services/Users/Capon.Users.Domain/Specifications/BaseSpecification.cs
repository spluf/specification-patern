using Capon.Users.Domain.Contracts.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Capon.Users.Domain.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public List<string> IncludeStrings { get; } = new List<string>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public Expression<Func<T, object>> GroupBy { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPaged { get; private set; } = false;


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public BaseSpecification() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public BaseSpecification(Expression<Func<T,bool>> criteria) => Criteria = criteria;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        protected void Include(Expression<Func<T, object>> include) => Includes.Add(include);
        protected void Include(string include) => IncludeStrings.Add(include);

        protected void Include(IEnumerable<Expression<Func<T, object>>> includes) => Includes.AddRange(includes);

        protected void Include(IEnumerable<string> includes) => IncludeStrings.AddRange(includes);

        protected void SetOrderBy(Expression<Func<T, object>> orderBy) => OrderBy = orderBy;

        protected void SetOrderByDescending(Expression<Func<T, object>> orderByDescending) => OrderByDescending = orderByDescending;

        protected void SetGroupBy(Expression<Func<T, object>> groupBy) => GroupBy = groupBy;

        protected void SetPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPaged = true;
        }
    }
}
