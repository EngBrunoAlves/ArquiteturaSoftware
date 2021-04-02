namespace BillsToPay.Domain.Interfaces.Repositories
{
	using BillsToPay.Domain.Entities;
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;
	using System.Threading.Tasks;

	public interface IRepositoryBase<TEntity> : IDisposable where TEntity : EntityBase
    {
        Task<int> SaveChanges();
        Task<TEntity> Add(TEntity entity);
        Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> entities);
        Task<TEntity> Update(TEntity entity);
        Task<IEnumerable<TEntity>> UpdateRange(IEnumerable<TEntity> entities);
        Task Remove(TEntity entity);
        Task Remove(Guid id);
        Task RemoveRange(IEnumerable<TEntity> entities);
        Task RemoveRange(IEnumerable<Guid> ids);
        Task<TEntity> GetById(Guid id);

        Task<bool> Any();
        Task<IEnumerable<TEntity>> List();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, int pageIndex, int size);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> order, int pageIndex, int size);
    }
}