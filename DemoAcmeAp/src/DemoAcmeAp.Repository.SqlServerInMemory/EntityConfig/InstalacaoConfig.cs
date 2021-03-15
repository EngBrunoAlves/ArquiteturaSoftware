namespace DemoAcmeAp.Repository.SqlServerInMemory.EntityConfig
{
    using DemoAcmeAp.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class InstalacaoConfig : IEntityTypeConfiguration<Instalacao>
    {
        public void Configure(EntityTypeBuilder<Instalacao> builder)
        {
            builder
                .Property(i => i.Codigo)
                .IsRequired()
                .HasMaxLength(8000);

            builder
                .Property(i => i.DataInstalacao)
                .IsRequired();

            builder
                .HasOne(i => i.Cliente)
                .WithMany(c => c.ListaInstalacao);

            builder
                .HasOne(i => i.EnderecoInstalacao);

            builder
                .HasMany(i => i.ListaFatura)
                .WithOne(f => f.Instalacao);

            builder
                .ToTable("Instalacao");
        }
    }
}