using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class TipoIncidenciaConfiguration : IEntityTypeConfiguration<TipoIncidencia>
{
    public void Configure(EntityTypeBuilder<TipoIncidencia> builder)
    {
        builder.ToTable("TipoIncidencia");

        builder.Property(p => p.Pk_Id)
            .HasColumnName("TipoIncidencia")
            .HasColumnType("varchar")
            .HasMaxLength(40)
            .IsRequired();

    }
}
