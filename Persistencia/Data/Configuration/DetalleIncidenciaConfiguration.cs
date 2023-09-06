using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class DetalleIncidenciaConfiguration : IEntityTypeConfiguration<DetalleIncidencia>
{
    public void Configure(EntityTypeBuilder<DetalleIncidencia> builder)
    {
        builder.ToTable("DetalleIncidencia");

        builder.Property(p => p.Pk_DetalleIncidencia)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("Pk_DetalleIncidencia")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.DescripcionIncidencia)
            .HasColumnName("DescripcionIncidencia")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.Fk_Incidencia)
            .HasColumnName("Fk_Incidencia")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Incidencias)
            .WithMany(p => p.DetalleDeIncidencias)
            .HasForeignKey(p => p.Fk_Incidencia);

        builder.Property(p => p.Fk_TipoIncidencia)
            .HasColumnName("Fk_TipoIncidencia")
            .HasColumnType("varchar")
            .HasMaxLength(40)
            .IsRequired();

        builder.HasOne(p => p.TiposDeIncidencias)
            .WithMany(p => p.DetalleDeIncidencias)
            .HasForeignKey(p => p.Fk_TipoIncidencia);

        builder.Property(p => p.Fk_NivelIncidencia)
            .HasColumnName("Fk_NivelIncidencia")
            .HasColumnType("varchar")
            .HasMaxLength(40)
            .IsRequired();

        builder.HasOne(p => p.NivelDeIncidencias)
            .WithMany(p => p.DetalleDeIncidencias)
            .HasForeignKey(p => p.Fk_NivelIncidencia);

        builder.Property(p => p.Fk_Herramienta)
            .HasColumnName("Fk_Herramienta")
            .HasColumnType("varchar")
            .HasMaxLength(40)
            .IsRequired();

        builder.HasOne(p => p.HerramientasDeTrabajo)
            .WithMany(p => p.DetalleDeIncidencias)
            .HasForeignKey(p => p.Fk_Herramienta);

    }
}
