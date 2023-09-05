namespace Dominio.Entities;
public class Incidencia : BaseEntity{

    public string ? Descripcion { get; set; }
    public int Usuario { get; set; }
    public string ? Area { get; set; }
    public Area ? Areas { get; set; }
    public string ? Lugar { get; set; }
    public Lugar ? Lugares { get; set; }
    public ICollection<DetalleIncidencia> ? DetalleIncidencias { get; set; }

}
