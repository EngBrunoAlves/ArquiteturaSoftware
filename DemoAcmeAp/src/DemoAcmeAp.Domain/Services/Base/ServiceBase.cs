namespace DemoAcmeAp.Domain.Services
{
    using DemoAcmeAp.Domain.Entities;
    using DemoAcmeAp.Domain.Interfaces.Repositories;
    using DemoAcmeAp.Domain.Interfaces.Services;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal abstract class ServiceBase<T> : IServiceBase<T> where T : EntityBase
    {
        private readonly IRepositoryBase<T> repository;

        protected ServiceBase(IRepositoryBase<T> repository)
        {
            this.repository = repository;
        }

        public async Task<T> Add(T entity)
        {
            return await repository.Add(entity);
        }

        public async Task<T> Update(long id, T entity)
        {
            if(entity.Id != id)
                throw new ArgumentException(nameof(entity));

            return await repository.Update(entity);
        }

        public async Task Delete(long id)
        {
            await repository.Remove(id);
        }

        public async Task<T> Get(long id)
        {
            return await repository.GetById(id);
        }

        public async Task<IEnumerable<T>> List()
        {
            return await repository.List();
        }
    }
}