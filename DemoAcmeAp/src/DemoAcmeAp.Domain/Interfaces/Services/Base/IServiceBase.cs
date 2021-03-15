namespace DemoAcmeAp.Domain.Interfaces.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DemoAcmeAp.Domain.Entities;

    public interface IServiceBase<T> where T : EntityBase
    {
        Task<T> Add(T entity);
        Task<T> Update(long id, T entity);
        Task Delete(long id);
        Task<T> Get(long id);
        Task<IEnumerable<T>> List();
    }
}