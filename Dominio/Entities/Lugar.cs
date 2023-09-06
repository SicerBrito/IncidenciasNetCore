namespace Dominio.Entities;
public class Lugar : BaseEntity{

    public string ? Area { get; set; }
    public Area ? Areas { get; set; }
    public ICollection<Incidencia> ? Incidencias { get; set; }

}
