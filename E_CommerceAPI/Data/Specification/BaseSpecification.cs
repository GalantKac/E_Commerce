using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace E_CommerceAPI.Data.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        /// <summary>
        /// Lista Includow
        /// </summary>
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderByAsc { get; private set; }

        public Expression<Func<T, object>> OrderByDesc { get; private set; }

        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPagingEnabled { get; private set; }

        /// <summary>
        /// Metoda dodajaca includ do listy
        /// </summary>
        /// <param name="includeExpression">wartosc includa</param>
        protected void AddInclude(Expression<Func<T,object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void AddOrderByAsc(Expression<Func<T, object>> orderByAscExpression)
        {
            OrderByAsc = orderByAscExpression;
        }
        protected void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDesc = orderByDescExpression;
        }

        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}
