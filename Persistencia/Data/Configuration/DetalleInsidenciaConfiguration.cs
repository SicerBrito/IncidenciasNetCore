using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class DetalleInsidenciaConfiguration : IEntityTypeConfiguration<DetalleInsidencia>
{
    public void Configure(EntityTypeBuilder<DetalleInsidencia> builder)
    {
        builder.ToTable(DetalleInsidencia);

        builder.Property(p => p.)
            .HasAnnotation(MySql:ValueGenerationStrategy, MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName()
            .HasColumnType()
            .IsRequired();

        builder.Property(p => p.)
            .HasColumnName()
            .HasColumnType()
            .HasMaxLength()
            .IsRequired();

        builder.HasOne(p => p.)
            .WithMany(p => p.)
            .HasForeignKey(p => p.);

        builder.HasMany(p => p.)
            .WithMany(p => p.)
            .UsingEntity<>(
                p => p
                    .HasOne(p => p.)
                    .WithMany(p => p.)
                    .HasForeignKey(p => p.),
                p => p
                    .HasOne(p => p.)
                    .WithMany(p => p.)
                    .HasForeignKey(p => p.),
                p => {
                    p.HasKey(p=> new {p.,p.});                    
                }
            );
    }
}
