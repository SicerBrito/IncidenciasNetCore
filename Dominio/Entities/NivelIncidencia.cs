namespace Dominio.Entities;
public class NivelIncidencia : BaseEntity{

    public ICollection<DetalleIncidencia> ? DetalleDeIncidencias { get; set; }
    
}
