namespace Dominio.Entities;
public class Lugar : BaseEntity{

    public ICollection<Profesor> ? Profesores { get; set; } = new HashSet<Profesor>();
    public ICollection<Salon> ? Salones { get; set;}
}
