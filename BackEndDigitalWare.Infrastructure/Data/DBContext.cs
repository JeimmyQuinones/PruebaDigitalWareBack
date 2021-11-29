using BackEndDigitalWare.Domain.Entities;
using BackEndDigitalWare.Infrastructure.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace BackEndDigitalWare.Infrastructure.Data
{
    public class DBContext:DbContext , IDBContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {
        }
        public const string DEFAULT_SHEMA = "DW";
        
        public DbSet<Bill> Bill { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<DetailBill> DetailBill { get; set; }
        public DbSet<IdentificationType> IdentificationType { get; set; }
        public DbSet<Mark> Mark { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BillEntityConfig.SetEntityBuilder(modelBuilder.Entity<Bill>());
            CustomerEntityConfig.SetEntityBuilder(modelBuilder.Entity<Customer>());
            DetailBillEntityConfig.SetEntityBuilder(modelBuilder.Entity<DetailBill>());
            IdentificationTypeEntityConfig.SetEntityBuilder(modelBuilder.Entity<IdentificationType>());
            MarkEntityConfig.SetEntityBuilder(modelBuilder.Entity<Mark>());
            ProductEntityConfig.SetEntityBuilder(modelBuilder.Entity<Product>());
            base.OnModelCreating(modelBuilder);
        }
    }
}
