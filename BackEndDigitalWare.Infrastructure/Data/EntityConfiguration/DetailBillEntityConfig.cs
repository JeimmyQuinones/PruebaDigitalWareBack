using BackEndDigitalWare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEndDigitalWare.Infrastructure.Data.EntityConfiguration
{
    public class DetailBillEntityConfig
    {
        /// <summary>
        /// Configuración parametros tabla
        /// </summary>
        /// <param name="entityBuilder"> Modelo</param>
        public static void SetEntityBuilder(EntityTypeBuilder<DetailBill> entityBuilder)
        {
            entityBuilder.ToTable("DetailBill", DBContext.DEFAULT_SHEMA);
            entityBuilder.HasKey(x => x.DetailBillId);
            entityBuilder.Property(x => x.DetailBillId).ValueGeneratedOnAdd();

            entityBuilder.Property(x => x.Amount).IsRequired();

            entityBuilder.HasOne(x => x.Bill).WithMany().HasForeignKey(x => x.BillId);
            entityBuilder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);


        }
    }
}
