namespace BillsToPay.Domain.Interfaces.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BillsToPay.Domain.Entities;

    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : EntityBase
    {
        Task<int> SaveChanges();
        Task<TEntity> Add(TEntity entity);
        Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> entities);
        Task<TEntity> Update(TEntity entity);
        Task<IEnumerable<TEntity>> UpdateRange(IEnumerable<TEntity> entities);
        Task Remove(TEntity entity);
        Task Remove(int id);
        Task RemoveRange(IEnumerable<TEntity> entities);
        Task RemoveRange(IEnumerable<int> ids);
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> List();
    }
}