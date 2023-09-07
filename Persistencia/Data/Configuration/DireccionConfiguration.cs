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

        builder.Property(p => p.FK_TipoVia)
            .HasColumnName("Fk_TipoVia")
            .HasColumnType("varchar")
            .HasMaxLength(40)
            .IsRequired();

        builder.HasOne(p => p.TipoDeVias)
            .WithMany(p => p.Direcciones)
            .HasForeignKey(p => p.FK_TipoVia);

        builder.Property(p => p.NroDireccion)
            .HasColumnName("NroDireccion")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Letra)
            .HasColumnName("Letra")
            .HasColumnType("varchar")
            .HasMaxLength(5)
            .IsRequired();

        builder.Property(p => p.SufijoCardinal)
            .HasColumnName("SufijoCardinal")
            .HasColumnType("varchar")
            .HasMaxLength(40)
            .IsRequired();

        builder.Property(p => p.FK_Usuario)
            .HasColumnName("FK_Usuario")
            .HasColumnType("BIGINT")
            .HasMaxLength(40)
            .IsRequired();

        builder.HasOne(p => p.Usuarios)
            .WithMany(p => p.Direcciones)
            .HasForeignKey(p => p.FK_Usuario);
    }
}
