namespace Dominio.Entities;
public class HerramientaTrabajo : BaseEntity{

    public ICollection<DetalleIncidencia> ? DetalleDeIncidencias { get; set; }

}
