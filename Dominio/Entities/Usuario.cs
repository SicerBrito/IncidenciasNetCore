namespace Dominio.Entities;
public class Usuario{

    public int Pk_IdUser { get; set; } 
    public string ? Nombres { get; set; }
    public string ? Apellidos { get; set; }
    public string ? Fk_Direccion { get; set; }
    public Direccion ? Direcciones { get; set; }
    public int NumeroDocumento { get; set; }
    public string ? FK_TipoDocumento { get; set; }
    public TipoDocumento ? TipoDeDocumentos { get; set; }
    public ICollection<Rol> ? Roles { get; set; } = new HashSet<Rol>();
    public ICollection<UsuarioRol> ? UsuariosRoles { get; set; }



}
