using System.ComponentModel.DataAnnotations;

namespace Dominio.Entities;
public class DetalleIncidencia{

    [Key]
    public int Pk_DetalleIncidencia { get; set; }
    public string ? DescripcionIncidencia { get; set; }
    public int Fk_Incidencia { get; set; }
    public Incidencia ? Incidencias { get; set; }
    public string ? Fk_TipoIncidencia { get; set; }
    public TipoIncidencia ? TiposDeIncidencias { get; set; }
    public string ? Fk_NivelIncidencia { get; set; }
    public NivelIncidencia ? NivelDeIncidencias { get; set; }
    public string ? Fk_Herramienta { get; set; }
    public HerramientaTrabajo ? HerramientasDeTrabajo { get; set; }

}
