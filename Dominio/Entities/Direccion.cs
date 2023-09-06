namespace Dominio.Entities;
    public class Direccion : BaseEntity{

        public string ? FK_TipoVia { get; set; }
        public TipoVia ? TipoDeVias { get; set; }
        public int NroDireccion { get; set; }
        public string ? Letra { get; set; }
        public string ? SufijoCardinal { get; set; }
        public int FK_Usuario { get; set; }
        public Usuario ? Usuarios { get; set; }
        
    }
