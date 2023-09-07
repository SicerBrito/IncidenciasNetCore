namespace Dominio.Entities;
public class Area : BaseEntity{

    public string ? Descripcion { get; set; }
    public ICollection<Lugar> ? Lugares { get; set; }
    public ICollection<AreaUsuario> ? AreaDeUsuarios{ get; set; }
    public ICollection<Incidencia> ? Incidencias { get; set; }
}
