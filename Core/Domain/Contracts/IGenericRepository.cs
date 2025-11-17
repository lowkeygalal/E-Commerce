using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IGenericRepository<TEntity,Tkey> where TEntity : BaseEntity<Tkey>
    {
        //GetAllAsync
        Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking=false);

        //GetByIdAsync
        Task<TEntity?> GetByIdAsync(Tkey id);

        //AddAsync
        Task AddAsync(TEntity entity);

        //Delete
        void Delete(TEntity entity);

        //Update
        void Update(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity,Tkey> specifications);

        Task<TEntity?> GetByIdAsync(ISpecifications<TEntity, Tkey> specifications);

        Task<int> CountAsync(ISpecifications<TEntity,Tkey> specifications);

    }
}
