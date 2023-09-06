namespace Dominio.Entities;
    public class TipoContacto : BaseEntity{
        
        public ICollection<Contacto> ? Contactos { get; set; }

    }
