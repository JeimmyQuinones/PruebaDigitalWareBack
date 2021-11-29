

using BackEndDigitalWare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEndDigitalWare.Infrastructure.Data.EntityConfiguration
{
    class CustomerEntityConfig
    {
        /// <summary>
        /// Configuración parametros tabla
        /// </summary>
        /// <param name="entityBuilder"> Modelo</param>
        public static void SetEntityBuilder(EntityTypeBuilder<Customer> entityBuilder)
        {
            entityBuilder.ToTable("Customer", DBContext.DEFAULT_SHEMA);
            entityBuilder.HasKey(x => x.CustomerId);
            entityBuilder.Property(x => x.CustomerId).ValueGeneratedOnAdd();

            entityBuilder.Property(x => x.Name).IsRequired();
            entityBuilder.Property(x => x.BirthDate).IsRequired();
            entityBuilder.Property(x => x.IdentificationNumber).IsRequired();
            entityBuilder.Property(x => x.Email).IsRequired();

            entityBuilder.HasOne(x => x.IdentificationType).WithMany().HasForeignKey(x => x.IdentificationTypeId);


        }
    }
}
