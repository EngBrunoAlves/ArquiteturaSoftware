namespace DemoAcmeAp.Repository.SqlServerInMemory.EntityConfig
{
    using DemoAcmeAp.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EnderecoConfig : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder
                .Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(8000);

            builder
                .Property(e => e.Numero)
                .IsRequired();

            builder
                .Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(8000);

            builder
                .Property(e => e.Cidade)
                .IsRequired()
                .HasMaxLength(8000);

            builder
                .Property(e => e.UF)
                .IsRequired()
                .HasMaxLength(2);

            builder
                .ToTable("Endereco");
        }
    }
}