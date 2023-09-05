namespace Dominio.Entities;
public class TipoIncidencia : BaseEntity{

    public ICollection<DetalleIncidencia> ? DetalleDeIncidencias { get; set; }
    
}
