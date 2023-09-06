using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class DireccionConfiguration : IEntityTypeConfiguration<Direccion>
{
    public void Configure(EntityTypeBuilder<Direccion> builder)
    {
        builder.ToTable("Direccion");

        builder.Property(p => p.Pk_Id)
            .HasColumnName("Pk_Direccion")
            .HasColumnType("varchar")
            .HasMaxLength(150)
            .IsRequired();
    }
}
