using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceAPI.Data.Specification
{
    /// <summary>
    /// Klasa majaca realizowac specyfikacje
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    public class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;

            // jesli nie puste dodanie kryteri do zapytania
            if (specification.Criteria != null)
                query = query.Where(specification.Criteria); // item => item.Id == id

            //dodawanie wszystkich (zalaczenie) obiektow z listy do zapytania
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}
