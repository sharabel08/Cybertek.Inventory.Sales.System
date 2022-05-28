using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cybertek.Entities.Repositories.Interfaces
{
    public interface IBaseEntityRepository<TEntity>
        where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task AddAsync(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, int pageNUmber, int pageSize);
        Task<TEntity> GetAsync (Guid id);
        Task<TEntity> GetAsync (Expression<Func<TEntity, bool>> expression);
        void Remove(TEntity entity);
        void Remove(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);
    }
}
