namespace DemoAcmeAp.Repository.SqlServerInMemory.EntityConfig
{
    using DemoAcmeAp.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
                .Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(8000);

            builder
                .Property(c => c.Cpf)
                .IsRequired()
                .HasMaxLength(14);

            builder
                .Property(c => c.DataNascimento)
                .IsRequired();

            builder
                .HasOne(c => c.EnderecoCobranca);

            builder
                .ToTable("Cliente");
        }
    }
}