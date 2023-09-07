using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario");

        builder.Property(p => p.Pk_IdUser)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IsUsuario")
            .HasColumnType("BIGINT")
            .IsRequired();

        builder.Property(p => p.FK_TipoDocumento)
            .HasColumnName("FK_TipoDocumento")
            .HasColumnType("varchar")
            .HasMaxLength(40)
            .IsRequired();

        builder.HasOne(p => p.TipoDeDocumentos)
            .WithMany(p => p.Usuarios)
            .HasForeignKey(p => p.FK_TipoDocumento);

        builder.Property(p => p.Nombres)
            .HasColumnName("Nombres")
            .HasColumnType("varchar")
            .HasMaxLength(60)
            .IsRequired();
        
        builder.Property(p => p.Apellidos)
            .HasColumnName("Apellidos")
            .HasColumnType("varchar")
            .HasMaxLength(60)
            .IsRequired();
            
    }
}
