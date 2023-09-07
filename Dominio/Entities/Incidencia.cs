using System.ComponentModel.DataAnnotations;

namespace Dominio.Entities;
public class Incidencia{

    [Key]
    public int PK_Id { get; set; }
    public string ? Descripcion { get; set; }
    public int Fk_Usuario { get; set; }
    public Usuario ? Usuarios { get; set; }
    public string ? Fk_Area { get; set; }
    public Area ? Areas { get; set; }
    public string ? Fk_Lugar { get; set; }
    public Lugar ? Lugares { get; set; }
    public DateTime Fecha { get; set; }
    public ICollection<DetalleIncidencia> ? DetalleDeIncidencias { get; set; }

}
