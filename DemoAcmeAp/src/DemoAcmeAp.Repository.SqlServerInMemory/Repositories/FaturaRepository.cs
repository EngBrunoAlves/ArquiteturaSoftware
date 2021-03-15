namespace DemoAcmeAp.Repository.SqlServerInMemory.Repositories
{
    using DemoAcmeAp.Domain.Entities;
    using DemoAcmeAp.Domain.Interfaces.Repositories;
    using DemoAcmeAp.Repository.SqlServerInMemory.Context;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal class FaturaRepository : RepositoryBase<Fatura>, IFaturaRepository
    {
        public FaturaRepository(DemoAcmeApContext context) : base(context) { }

        public async Task<Fatura> FindByCodigo(string codigo)
        {
            return await DbSet
                .Where(f => f.Codigo.Equals(codigo))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Fatura>> FindByClienteCpf(string clienteCpf)
        {
            return await DbSet
                .Where(f => f.Instalacao.Cliente.Cpf.Equals(clienteCpf))
                .ToListAsync();
        }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}