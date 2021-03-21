namespace OpenWeather.Repository.SqlServerInMemory.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using OpenWeather.Domain.Entities;
    using OpenWeather.Domain.Interfaces.Repositories;
    using OpenWeather.Repository.SqlServerInMemory.Context;

    internal abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        #region Constructor
        protected OpenWeatherDbContext Db;
        protected DbSet<TEntity> DbSet;

        internal RepositoryBase(OpenWeatherDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public abstract void Dispose();
        #endregion

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

        public virtual async Task Remove(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Deleted;
        }

        public virtual async Task Remove(long id)
        {
            var entity = await DbSet.FindAsync(id);
            await Remove(entity);
        }

        public virtual async Task RemoveRange(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public virtual async Task RemoveRange(IEnumerable<long> ids)
        {
            foreach (var id in ids)
                await Remove(id);
        }

        public virtual async Task<TEntity> GetById(long id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> List()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> List(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        protected async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
    }
}