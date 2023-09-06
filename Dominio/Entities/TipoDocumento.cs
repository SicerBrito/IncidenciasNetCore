namespace Dominio.Entities;
public class TipoDocumento : BaseEntity{

    public ICollection<Usuario> ? Usuarios { get; set; }
    
}
