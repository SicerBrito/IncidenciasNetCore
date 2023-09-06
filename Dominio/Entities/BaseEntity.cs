using System.ComponentModel.DataAnnotations;

namespace Dominio.Entities;
public class BaseEntity{

    [Key]
    public string ? Pk_Id { get; set; }
    
}
