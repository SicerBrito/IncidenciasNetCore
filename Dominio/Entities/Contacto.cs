namespace Dominio.Entities;
public class Contacto{

    public int Numero { get; set; }
    public string ? TipoContacto { get; set; }
    public TipoContacto ? TipoDeContactos { get; set; }
    
}
