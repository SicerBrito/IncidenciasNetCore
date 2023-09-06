using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Data;
public class SicerContext : DbContext{
    public SicerContext(DbContextOptions<SicerContext> options) : base(options){

    }

    public DbSet<Area> Areas { get; set; } = null!;
    public DbSet<AreaUsuario> AreaUsuarios { get; set; } = null!;
    public DbSet<Contacto> Contactos { get; set; } = null!;
    public DbSet<DetalleIncidencia> DetalleDeIncidencias { get; set; } = null!;
    public DbSet<Direccion> Direccion { get; set; } = null!;
    public DbSet<HerramientaTrabajo> HerramientasDeTrabajo { get; set; } = null!;
    public DbSet<Incidencia> Incidencias { get; set; } = null!;
    public DbSet<Lugar> Lugares { get; set; } = null!;
    public DbSet<NivelIncidencia> NivelDeIncidencias { get; set; } = null!;
    public DbSet<Rol> Rols { get; set; } = null!;
    public DbSet<TipoDocumento> TipoDeDocumentos { get; set; } = null!;
    public DbSet<TipoIncidencia> TipoDeIncidencias { get; set; } = null!;
    public DbSet<TipoVia> TipoDeVias { get; set; } = null!;
    public DbSet<Usuario> Usuarios { get; set; } = null!;
    public DbSet<UsuarioRol> UsuarioRols { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
