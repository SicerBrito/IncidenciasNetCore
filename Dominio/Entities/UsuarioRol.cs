using System.ComponentModel.DataAnnotations;

namespace Dominio.Entities;
    public class UsuarioRol{

        [Key]
        public int IdUsuarioRol { get; set; }
        public int Fk_UsuarioId { get; set; }
        public Usuario ? Usuarios { get; set; }
        public string ? Fk_Rol { get; set; }
        public Rol ? Rol { get; set; }
        
}
