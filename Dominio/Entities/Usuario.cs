using System.ComponentModel.DataAnnotations;

namespace Dominio.Entities;
public class Usuario{

    [Key]
    public int Pk_IdUser { get; set; } 
    public string ? FK_TipoDocumento { get; set; }
    public TipoDocumento ? TipoDeDocumentos { get; set; }
    public string ? Nombres { get; set; }
    public string ? Apellidos { get; set; }
    public string ? Fk_Direccion { get; set; }
    public Direccion ? Direcciones { get; set; }
    public int NumeroDocumento { get; set; }
    public ICollection<Rol> ? Roles { get; set; } = new HashSet<Rol>();
    public ICollection<UsuarioRol> ? UsuariosRoles { get; set; }
    public ICollection<AreaUsuario> ? AreaDeUsuarios { get; set; }
    public ICollection<Contacto> ? Contactos { get; set; }


}
