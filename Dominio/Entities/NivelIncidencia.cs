namespace Dominio.Entities;
public class NivelIncidencia : BaseEntity{

    public string ? Descripcion { get; set; }
    public ICollection<DetalleIncidencia> ? DetalleDeIncidencias { get; set; }
    
}
