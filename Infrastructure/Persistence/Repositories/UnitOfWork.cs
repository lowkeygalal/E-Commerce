using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UnitOfWork(StoreDbContext _dbContext) : IUnitOfWork
    {
        private ConcurrentDictionary<string,object> _repositories = new ConcurrentDictionary<string,object>();

        public IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>()
            where TEntity : BaseEntity<Tkey>
         =>(IGenericRepository<TEntity,Tkey>)   _repositories.GetOrAdd(typeof(TEntity).Name,(_)=>new GenericRepository<TEntity,Tkey>(_dbContext));

        public Task<int> SaveChangesAsync()
        =>_dbContext.SaveChangesAsync();
    }
}
