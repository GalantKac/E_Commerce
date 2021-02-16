using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DB_E_CommerceContext _dB_E_CommerceContext;
        private Hashtable _repositories;

        public UnitOfWork(DB_E_CommerceContext dB_E_CommerceContext)
        {
            _dB_E_CommerceContext = dB_E_CommerceContext;
        }

        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            if (_repositories == null) _repositories = new Hashtable();

            var key = typeof(T).Name;

            if (!_repositories.ContainsKey(key))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dB_E_CommerceContext);

                _repositories.Add(key, repositoryInstance);
            }

            return (IGenericRepository<T>)_repositories[key];
        }

        public async Task<int> Complete()
        {
            return await _dB_E_CommerceContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dB_E_CommerceContext.Dispose();
        }
    }
}
