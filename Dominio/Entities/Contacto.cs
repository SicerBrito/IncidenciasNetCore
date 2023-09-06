using System.ComponentModel.DataAnnotations;

namespace Dominio.Entities;
public class Contacto{

    [Key]
    public int Pk_Numero { get; set; }
    public string ? Fk_TipoContacto { get; set; }
    public TipoContacto ? TipoDeContactos { get; set; }
    public int Fk_Usuario { get; set; }
    public Usuario ? Usuarios { get; set; }
    
}
