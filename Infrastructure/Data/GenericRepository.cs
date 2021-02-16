using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    /// <summary>
    /// Klas generyczna której metody zwaracaj wynik zapytań z bazy danych
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DB_E_CommerceContext _context;

        public GenericRepository(DB_E_CommerceContext context)
        {
            _context = context;
        }

        #region Class Methods
        private IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;

            // jesli nie puste dodanie kryteri do zapytania
            if (specification.Criteria != null)
                query = query.Where(specification.Criteria); // item => item.Id == id

            if (specification.OrderByAsc != null)
                query = query.OrderBy(specification.OrderByAsc);

            if (specification.OrderByDesc != null)
                query = query.OrderByDescending(specification.OrderByDesc);

            if (specification.IsPagingEnabled)
                query = query.Skip(specification.Skip).Take(specification.Take); //skip elements , take elements

            //dodawanie wszystkich (zalaczenie) obiektow z listy do zapytania
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }

        #endregion Class Methods

        #region Extend Interfaces Methods

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithSpecification(ISpecification<T> specification)
        {
            return await GetQuery(_context.Set<T>().AsQueryable(), specification).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification)
        {
            //_context.Set<T>().AsQueryable() - zapytanie do tabeli T , specyfiakcja to wszystkie warunki , na końcu w jakiej postaci
            return await GetQuery(_context.Set<T>().AsQueryable(), specification).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> specification)
        {
            return await GetQuery(_context.Set<T>().AsQueryable(), specification).CountAsync();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        #endregion Extend Interfaces Methods
    }
}
