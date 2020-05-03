using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace E_CommerceAPI.Data.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; } // kryteria do zapytania
        List<Expression<Func<T, object>>> Includes { get; } // lista obiektow dolaczonych
    }
}
