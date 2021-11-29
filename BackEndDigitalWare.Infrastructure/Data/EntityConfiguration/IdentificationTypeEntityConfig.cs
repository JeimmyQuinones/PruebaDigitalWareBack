using BackEndDigitalWare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEndDigitalWare.Infrastructure.Data.EntityConfiguration
{
    public class IdentificationTypeEntityConfig
    {
        /// <summary>
        /// Configuración parametros tabla
        /// </summary>
        /// <param name="entityBuilder"> Modelo</param>
        public static void SetEntityBuilder(EntityTypeBuilder<IdentificationType> entityBuilder)
        {
            entityBuilder.ToTable("IdentificationType", DBContext.DEFAULT_SHEMA);
            entityBuilder.HasKey(x => x.IdentificationTypeId);
            entityBuilder.Property(x => x.IdentificationTypeId).ValueGeneratedOnAdd();

            entityBuilder.Property(x => x.Name).IsRequired();
            entityBuilder.Property(x => x.Synonymous).IsRequired();


        }
    }
}
