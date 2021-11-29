using BackEndDigitalWare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEndDigitalWare.Infrastructure.Data.EntityConfiguration
{
    public class ProductEntityConfig
    {
        /// <summary>
        /// Configuración parametros tabla
        /// </summary>
        /// <param name="entityBuilder"> Modelo</param>
        public static void SetEntityBuilder(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.ToTable("Product", DBContext.DEFAULT_SHEMA);
            entityBuilder.HasKey(x => x.ProductId);
            entityBuilder.Property(x => x.ProductId).ValueGeneratedOnAdd();

            entityBuilder.Property(x => x.Name).IsRequired();
            entityBuilder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,4)"); ;
            entityBuilder.Property(x => x.Amount).IsRequired();
            entityBuilder.Property(x => x.Availability).IsRequired();
            entityBuilder.HasOne(x => x.Mark).WithMany().HasForeignKey(x => x.MarkId);


        }
    }
}
