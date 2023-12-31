using System.ComponentModel.DataAnnotations;

namespace Dominio.Entities;
public class AreaUsuario{

    [Key]
    public int Pk_AreaUsuario { get; set; }
    public int Fk_Usuario { get; set; }
    public Usuario ? Usuarios { get; set; }
    public string ? Fk_Area { get; set; }
    public Area ? Areas { get; set; }

}
