namespace Dominio.Entities;
    public class UsuarioRol{

        public int Fk_UsuarioId { get; set; }
        public Usuario ? Usuarios { get; set; }
        public string ? Fk_Rol { get; set; }
        public Rol ? Rol { get; set; }
        
}
