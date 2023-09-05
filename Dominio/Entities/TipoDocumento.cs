namespace Dominio.Entities;
public class TipoDocumento : BaseEntity{

    public ICollection<Profesor> ? Profesores { get; set; } = new HashSet<Profesor>();
    public ICollection<Salon> ? Salones { get; set;}
}
