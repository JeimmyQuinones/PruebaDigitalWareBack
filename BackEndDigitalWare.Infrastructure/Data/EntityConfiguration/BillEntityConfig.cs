using BackEndDigitalWare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEndDigitalWare.Infrastructure.Data.EntityConfiguration
{
    public class BillEntityConfig
    {
        /// <summary>
        /// Configuración parametros tabla
        /// </summary>
        /// <param name="entityBuilder"> Modelo</param>
        public static void SetEntityBuilder(EntityTypeBuilder<Bill> entityBuilder)
        {
            entityBuilder.ToTable("Bill", DBContext.DEFAULT_SHEMA);
            entityBuilder.HasKey(x => x.BillId);
            entityBuilder.Property(x => x.BillId).ValueGeneratedOnAdd();

            entityBuilder.Property(x => x.Date).IsRequired();
            entityBuilder.Property(x => x.Total).IsRequired().HasColumnType("decimal(18,4)"); 

            entityBuilder.HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.CustomerId);


        }
    }
}