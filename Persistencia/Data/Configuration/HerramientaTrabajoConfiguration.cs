using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class HerramientaTrabajoConfiguration : IEntityTypeConfiguration<HerramientaTrabajo>
{
    public void Configure(EntityTypeBuilder<HerramientaTrabajo> builder)
    {
        builder.ToTable("HerramientaTrabajo");

        builder.Property(p => p.Pk_Id)
            .HasColumnName("Pk_NombreHerramienta")
            .HasColumnType("varchar")
            .HasMaxLength(40)
            .IsRequired();

    }
}
