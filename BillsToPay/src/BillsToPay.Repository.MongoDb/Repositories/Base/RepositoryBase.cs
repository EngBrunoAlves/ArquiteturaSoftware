namespace BillsToPay.Repository.MongoDb.Repositories
{
    using BillsToPay.Domain.Entities;
    using BillsToPay.Domain.Interfaces.Repositories;
    using BillsToPay.Repository.MongoDb.Context;
    using MongoDB.Driver;
    using Polly;
    using Polly.Retry;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    internal abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        #region MongoSpecific

        public RepositoryBase(BillsToPayContext context)
        {
            Collection = context.GetCollection<TEntity>();
        }

        public IMongoCollection<TEntity> Collection { get; private set; }
        #endregion

        public Task<int> SaveChanges()
        {
            return Task.FromResult(1);
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            return await Retry(() =>
            {
                Collection.InsertOne(entity);
                return Collection.Find(x => x.Id == entity.Id).FirstOrDefaultAsync();
            });
        }

        public virtual async Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> entities)
        {
            return await Retry(async () =>
            {
                await Collection.InsertManyAsync(entities);
                var ids = entities.Select(e => e.Id);
                return await Collection.Find(f => ids.Any(id => id == f.Id)).ToListAsync();
            });
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            return await Retry(async () =>
            {
                await Collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
                return await Collection.Find(x => x.Id == entity.Id).FirstOrDefaultAsync();
            });
        }

        public async Task<IEnumerable<TEntity>> UpdateRange(IEnumerable<TEntity> entities)
        {
            return await Retry(() =>
            {
                var tasks = entities.Select(x => Update(x)).ToArray();
                return Task.WhenAll(tasks);
            });
        }

        public async Task Remove(TEntity entity)
        {
            await Retry(() =>
            {
                return Collection.DeleteOneAsync(x => x.Id == entity.Id);
            });
        }

        public async Task Remove(Guid id)
        {
            await Retry(() =>
            {
                return Collection.DeleteOneAsync(x => x.Id == id);
            });
        }

        public async Task RemoveRange(IEnumerable<TEntity> entities)
        {
            await Retry(() =>
            {
                var ids = entities.Select(e => e.Id);
                return Collection.DeleteManyAsync(x => ids.Any(id => id == x.Id));
            });
        }

        public async Task RemoveRange(IEnumerable<Guid> ids)
        {
            await Retry(() =>
            {
                return Collection.DeleteManyAsync(x => ids.Any(id => id == x.Id));
            });
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await Retry(() =>
           {
               return Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
           });
        }

        public async Task<bool> Any()
        {
            return await Retry(() => {
                return Collection.Find(_ => true).AnyAsync();
            });
        }

        public async Task<IEnumerable<TEntity>> List()
        {
            return await Retry(() =>
            {
                return Collection.Find(_ => true).ToListAsync();
            });
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await Retry(() =>
            {
                return Collection.Find(predicate).ToListAsync();
            });
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, int pageIndex, int size)
        {
            return await Retry(() =>
            {
                return Collection.Find(predicate).Skip(pageIndex).Limit(size).ToListAsync();
            });
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> order, int pageIndex, int size)
        {
            return await Retry(() =>
            {
                return Collection.Find(predicate).SortByDescending(order).Skip(pageIndex).Limit(size).ToListAsync();
            });
        }

        #region RetryPolicy
        protected virtual TResult Retry<TResult>(Func<TResult> action) =>
            RetryPolicy
            .Handle<MongoConnectionException>(i => i.InnerException.GetType() == typeof(IOException) || i.InnerException.GetType() == typeof(SocketException))
            .Retry(3)
            .Execute(action);
        #endregion

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
