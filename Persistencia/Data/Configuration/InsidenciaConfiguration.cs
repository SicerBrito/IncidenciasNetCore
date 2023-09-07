using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class IncidenciaConfiguration : IEntityTypeConfiguration<Incidencia>
{
    public void Configure(EntityTypeBuilder<Incidencia> builder)
    {
        builder.ToTable("Incidencia");

        builder.Property(p => p.PK_Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("PK_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Descripcion)
            .HasColumnName("Descripcion")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();


        builder.Property(p => p.Fk_Usuario)
            .HasColumnName("Fk_Usuario")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Usuarios)
            .WithMany(p => p.Incidencias)
            .HasForeignKey(p => p.Fk_Usuario);

        builder.Property(p => p.Fk_Area)
            .HasColumnName("Fk_Area")
            .HasColumnType("varchar")
            .HasMaxLength(40)
            .IsRequired();

        builder.HasOne(p => p.Areas)
            .WithMany(p => p.Incidencias)
            .HasForeignKey(p => p.Fk_Area);

        builder.Property(p => p.Fk_Lugar)
            .HasColumnName("Fk_Lugar")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();

        builder.HasOne(p => p.Lugares)
            .WithMany(p => p.Incidencias)
            .HasForeignKey(p => p.Fk_Lugar);

        builder.Property(p => p.Fecha)
            .HasColumnName("Fecha")
            .HasColumnType("date")
            .IsRequired();

    }
}
