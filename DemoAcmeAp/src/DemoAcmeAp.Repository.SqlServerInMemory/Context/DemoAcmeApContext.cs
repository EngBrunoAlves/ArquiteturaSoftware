namespace DemoAcmeAp.Repository.SqlServerInMemory.Context
{
    using DemoAcmeAp.Domain.Entities;
    using DemoAcmeAp.Repository.SqlServerInMemory.EntityConfig;
    using Microsoft.EntityFrameworkCore;

    public class DemoAcmeApContext : DbContext
    {
        public DemoAcmeApContext(DbContextOptions<DemoAcmeApContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new EnderecoConfig());
            modelBuilder.ApplyConfiguration(new FaturaConfig());
            modelBuilder.ApplyConfiguration(new InstalacaoConfig());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Fatura> Fatura { get; set; }
        public DbSet<Instalacao> Instalacao { get; set; }
    }
}