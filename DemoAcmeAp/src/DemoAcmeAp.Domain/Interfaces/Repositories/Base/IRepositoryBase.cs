namespace DemoAcmeAp.Domain.Interfaces.Repositories
{
    using DemoAcmeAp.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : EntityBase
    {
        Task<int> SaveChanges();
        Task<TEntity> Add(TEntity entity);
        Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> entities);
        Task<TEntity> Update(TEntity entity);
        Task<IEnumerable<TEntity>> UpdateRange(IEnumerable<TEntity> entities);
        Task Remove(TEntity entity);
        Task Remove(long id);
        Task RemoveRange(IEnumerable<TEntity> entities);
        Task RemoveRange(IEnumerable<long> ids);
        Task<TEntity> GetById(long id);
        Task<IEnumerable<TEntity>> List();
    }
}