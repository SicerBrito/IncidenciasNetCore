using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class LugarConfiguration : IEntityTypeConfiguration<Lugar>
{
    public void Configure(EntityTypeBuilder<Lugar> builder)
    {
        builder.ToTable("Lugar");

        builder.Property(p => p.Pk_Id)
            .HasColumnName("Lugar")
            .HasColumnType("varchar")
            .IsRequired();

        builder.Property(p => p.Fk_Area)
            .HasColumnName("Fk_Area")
            .HasColumnType("varchar")
            .HasMaxLength(40)
            .IsRequired();

        builder.HasOne(p => p.Areas)
            .WithMany(p => p.Lugares)
            .HasForeignKey(p => p.Fk_Area);

    }
}
