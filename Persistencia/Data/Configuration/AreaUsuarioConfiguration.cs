using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class AreaUsuarioConfiguration : IEntityTypeConfiguration<AreaUsuario>
{
    public void Configure(EntityTypeBuilder<AreaUsuario> builder)
    {
        builder.ToTable("AreaUsuario");

        builder.Property(p => p.Fk_Usuario)
            .HasColumnName("Fk_Usuario")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Usuarios)
            .WithMany(p => p.AreaDeUsuarios)
            .HasForeignKey(p => p.Fk_Usuario);

        builder.Property(p => p.Fk_Area)
            .HasColumnName("Fk_Area")
            .HasColumnType("varchar")
            .HasMaxLength(40)
            .IsRequired();

        builder.HasOne(p => p.Areas)
            .WithMany(p => p.AreaDeUsuarios)
            .HasForeignKey(p => p.Fk_Area);

    }
}
