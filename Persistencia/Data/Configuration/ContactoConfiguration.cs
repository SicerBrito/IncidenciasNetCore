using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class ContactoConfiguration : IEntityTypeConfiguration<Contacto>
{
    public void Configure(EntityTypeBuilder<Contacto> builder)
    {
        builder.ToTable("Contacto");

        builder.Property(p => p.Pk_Numero)
            .HasColumnName("Pk_Numero")
            .HasColumnType("BIGINT")
            .IsRequired();

        builder.Property(p => p.Fk_TipoContacto)
            .HasColumnName("Fk_TipoContacto")
            .HasColumnType("varchar")
            .HasMaxLength(40)
            .IsRequired();

        builder.HasOne(p => p.TipoDeContactos)
            .WithMany(p => p.Contactos)
            .HasForeignKey(p => p.Fk_TipoContacto);

        builder.Property(p => p.Fk_Usuario)
            .HasColumnName("Fk_Usuario")
            .HasColumnType("BIGINT")
            .IsRequired();

        builder.HasOne(p => p.Usuarios)
            .WithMany(p => p.Contactos)
            .HasForeignKey(p => p.Fk_Usuario);

    }
}
