namespace Dominio.Entities;
    public class Direccion{

        public string ? PK_Direccion { get; set; }
        public string ? FK_TipoVia { get; set; }
        public TipoVia ? TipoDeVias { get; set; }
        public int NroDireccion { get; set; }
        public string ? Letra { get; set; }
        public string ? SufijoCardinal { get; set; }
        public int NroViaSecundaria { get; set; }
        public string ? LetraVS { get; set; }
        public string ? SufijoCardinalVS { get; set; }
        public int FK_Usuario { get; set; }
        public Usuario ? Usuarios { get; set; }
        
    }
