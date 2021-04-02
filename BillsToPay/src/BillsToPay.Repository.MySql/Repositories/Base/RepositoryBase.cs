namespace BillsToPay.Repository.MySql.Repositories
{
    using BillsToPay.Domain.Entities;
    using BillsToPay.Domain.Interfaces.Repositories;
    using BillsToPay.Repository.MySql.Context;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    internal abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        #region Constructor
        protected BillsToPayContext Db;
        protected DbSet<TEntity> DbSet;

        internal RepositoryBase(BillsToPayContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }
        #endregion

        public virtual async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> entities)
        {
            await DbSet.AddRangeAsync(entities);
            return entities;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            var entry = Db.Entry(entity);
            entry.State = EntityState.Modified;
            return await DbSet.FindAsync(entity.Id);
        }

        public virtual async Task<IEnumerable<TEntity>> UpdateRange(IEnumerable<TEntity> entities)
        {
            var entitiesUpdated = new List<TEntity>();
            foreach (var entity in entities)
                entitiesUpdated.Add(await Update(entity));
            return entitiesUpdated;
        }

        public virtual Task Remove(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Deleted;
            return Task.CompletedTask;
        }

        public virtual async Task Remove(Guid id)
        {
            var entity = await DbSet.FindAsync(id);
            await Remove(entity);
        }

        public virtual Task RemoveRange(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public virtual async Task RemoveRange(IEnumerable<Guid> ids)
        {
            foreach (var id in ids)
                await Remove(id);
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<bool> Any()
        {
            return await DbSet.AnyAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> List()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> List(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }
        
        public async  Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, int pageIndex, int size)
        {
            return await DbSet.Where(predicate).Skip(pageIndex).Take(size).ToListAsync();
        }

        public async  Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> order, int pageIndex, int size)
        {
            return await DbSet.Where(predicate).OrderBy(order).Skip(pageIndex).Take(size).ToListAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}