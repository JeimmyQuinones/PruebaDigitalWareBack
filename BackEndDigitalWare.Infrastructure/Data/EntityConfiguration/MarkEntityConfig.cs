using BackEndDigitalWare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEndDigitalWare.Infrastructure.Data.EntityConfiguration
{
    public class MarkEntityConfig
    {
        /// <summary>
        /// Configuración parametros tabla
        /// </summary>
        /// <param name="entityBuilder"> Modelo</param>
        public static void SetEntityBuilder(EntityTypeBuilder<Mark> entityBuilder)
        {
            entityBuilder.ToTable("Mark", DBContext.DEFAULT_SHEMA);
            entityBuilder.HasKey(x => x.MarkId);
            entityBuilder.Property(x => x.MarkId).ValueGeneratedOnAdd();

            entityBuilder.Property(x => x.Name).IsRequired();


        }
    }
}
