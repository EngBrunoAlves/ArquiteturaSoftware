namespace DemoAcmeAp.Repository.SqlServerInMemory.EntityConfig
{
    using DemoAcmeAp.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class FaturaConfig : IEntityTypeConfiguration<Fatura>
    {
        public void Configure(EntityTypeBuilder<Fatura> builder)
        {
            builder
                .Property(f => f.Codigo)
                .IsRequired()
                .HasMaxLength(8000);

            builder
                .Property(f => f.DataLeitura)
                .IsRequired();

            builder
                .Property(f => f.DataVencimento)
                .IsRequired();

            builder
                .Property(f => f.NumeroLeitura)
                .IsRequired();

            builder
                .Property(f => f.ValorConta)
                .IsRequired();

            builder
                .HasOne(f => f.Instalacao)
                .WithMany(i => i.ListaFatura);

            builder
                .ToTable("Fatura");
        }
    }
}