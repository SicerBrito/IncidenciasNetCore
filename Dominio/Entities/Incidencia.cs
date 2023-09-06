using System.ComponentModel.DataAnnotations;

namespace Dominio.Entities;
public class Incidencia{

    [Key]
    public int PK_Id { get; set; }
    public string ? Descripcion { get; set; }
    public int Usuario { get; set; }
    public string ? Area { get; set; }
    public Area ? Areas { get; set; }
    public string ? Lugar { get; set; }
    public Lugar ? Lugares { get; set; }
    public DateTime Fecha { get; set; }
    public ICollection<DetalleIncidencia> ? DetalleDeIncidencias { get; set; }

}
