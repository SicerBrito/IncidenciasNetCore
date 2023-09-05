namespace Dominio.Entities;
public class DetalleIncidencia{

    public string ? DescripcionIncidencia { get; set; }
    public string ? Incidencia { get; set; }
    public Incidencia ? Incidencias { get; set; }
    public string ? TipoIncidencia { get; set; }
    public string ? NivelIncidencia { get; set; }
    public string ? Fk_Herramienta { get; set; }
    public HerramientaTrabajo ? HerramientasDeTrabajo { get; set; }

}
