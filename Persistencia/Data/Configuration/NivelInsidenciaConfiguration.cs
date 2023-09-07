using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class NivelIncidenciaConfiguration : IEntityTypeConfiguration<NivelIncidencia>
{
    public void Configure(EntityTypeBuilder<NivelIncidencia> builder)
    {
        builder.ToTable("NivelIncidencia");

        builder.Property(p => p.Pk_Id)
            .HasColumnName("NivelIncidencia")
            .HasColumnType("varchar")
            .HasMaxLength(40)
            .IsRequired();

        builder.Property(p => p.Descripcion)
            .HasColumnName("Descripcion")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();

    }
}
