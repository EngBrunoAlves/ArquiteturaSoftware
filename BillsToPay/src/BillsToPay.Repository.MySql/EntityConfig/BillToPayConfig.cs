namespace BillsToPay.Repository.MySql.EntityConfig
{
    using BillsToPay.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BillToPayConfig : IEntityTypeConfiguration<BillToPay>
    {
        public void Configure(EntityTypeBuilder<BillToPay> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(8000);
        }
    }
}