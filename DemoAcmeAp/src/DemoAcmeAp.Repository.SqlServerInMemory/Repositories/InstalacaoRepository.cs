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

    internal class InstalacaoRepository : RepositoryBase<Instalacao>, IInstalacaoRepository
    {
        public InstalacaoRepository(DemoAcmeApContext context) : base(context) { }

        public async Task<Instalacao> FindByCodigo(string codigo)
        {
            return await DbSet
                .Where(i => i.Codigo.Equals(codigo))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Instalacao>> FindByClienteCpf(string clientCpf)
        {
            return await DbSet
                .Where(i => i.Cliente.Cpf.Equals(clientCpf))
                .ToListAsync();
        }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}