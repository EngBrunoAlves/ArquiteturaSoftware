using BillsToPay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillsToPay.Domain.Interfaces.Services
{
	public interface IServiceBase<T> : IDisposable where T : EntityBase
	{
		Task<T> Add(T entity);
		Task<T> Update(Guid id, T entity);
		Task Delete(Guid id);
		Task<T> Get(Guid id);
		Task<IEnumerable<T>> List();
	}
}
