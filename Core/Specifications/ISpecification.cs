﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; } // kryteria do zapytania
        List<Expression<Func<T, object>>> Includes { get; } // lista obiektow dolaczonych

        Expression<Func<T, object>> OrderByAsc { get; }
        Expression<Func<T, object>> OrderByDesc { get; }

        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }
    }
}