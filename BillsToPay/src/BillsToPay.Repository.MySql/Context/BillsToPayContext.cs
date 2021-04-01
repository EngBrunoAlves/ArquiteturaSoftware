namespace BillsToPay.Repository.MySql.Context
{
    using BillsToPay.Domain.Entities;
    using BillsToPay.Repository.MySql.EntityConfig;
    using Microsoft.EntityFrameworkCore;

    internal sealed class BillsToPayContext : DbContext
    {
        public BillsToPayContext(DbContextOptions<BillsToPayContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BillToPayConfig());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<BillToPay> BillToPay { get; set; }
        public DbSet<LateFee> LateFee { get; set; }
    }
}