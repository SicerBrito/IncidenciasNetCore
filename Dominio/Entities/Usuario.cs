using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Dominio.Entities;
public class Usuario{

    [Key]
    public int Pk_IdUser { get; set; } 
    public string ? FK_TipoDocumento { get; set; }
    public TipoDocumento ? TipoDeDocumentos { get; set; }
    public string ? Email { get; set; }
    public string ? Password { get; set; }
    public string ? Nombres { get; set; }
    public string ? Apellidos { get; set; }
    public ICollection<Rol> ? Roles { get; set; } = new HashSet<Rol>();
    public ICollection<UsuarioRol> ? UsuariosRoles { get; set; }
    public ICollection<AreaUsuario> ? AreaDeUsuarios { get; set; }
    public ICollection<Contacto> ? Contactos { get; set; }
    public ICollection<Incidencia> ? Incidencias { get; set; }
    public ICollection<Direccion> ? Direcciones { get; set; }
}
