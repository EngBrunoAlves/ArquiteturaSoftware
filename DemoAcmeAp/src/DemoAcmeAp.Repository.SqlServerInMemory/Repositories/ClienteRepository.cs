namespace DemoAcmeAp.Repository.SqlServerInMemory.Repositories
{
    using DemoAcmeAp.Domain.Entities;
    using DemoAcmeAp.Domain.Interfaces.Repositories;
    using DemoAcmeAp.Repository.SqlServerInMemory.Context;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    internal class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(DemoAcmeApContext context) : base(context) { }

        public async Task<Cliente> FindByCpf(string cpf)
        {
            return await DbSet
                .Where(c => c.Cpf.Equals(cpf))
                .FirstOrDefaultAsync();
        }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}