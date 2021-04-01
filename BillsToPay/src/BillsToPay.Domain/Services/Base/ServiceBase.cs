using BillsToPay.Domain.Entities;
using BillsToPay.Domain.Interfaces.Repositories;
using BillsToPay.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillsToPay.Domain.Services
{
	internal abstract class ServiceBase<T> : IServiceBase<T> where T : EntityBase
	{
		private readonly IRepositoryBase<T> _repository;
		protected bool disposedValue;

		protected ServiceBase(IRepositoryBase<T> repository)
		{
			_repository = repository;
		}

		public async virtual Task<T> Add(T entity)
		{
			return await _repository.Add(entity);
		}

		public async virtual Task<T> Update(Guid id, T entity)
		{
			if (entity.Id != id)
				throw new ArgumentException(nameof(entity));

			return await _repository.Update(entity);
		}

		public async virtual Task Delete(Guid id)
		{
			await _repository.Remove(id);
		}

		public async virtual Task<T> Get(Guid id)
		{
			return await _repository.GetById(id);
		}

		public async virtual Task<IEnumerable<T>> List()
		{
			return await _repository.List();
		}

		protected abstract void Dispose(bool disposing);

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
