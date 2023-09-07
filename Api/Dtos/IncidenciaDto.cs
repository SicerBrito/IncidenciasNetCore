namespace ApiIncidencePro.Dtos;
public class IncidenciaDto
{
    public int IncidenciaId { get; set; }
    public string ? IncidenciaDescription { get; set; }
    public DateTime IncidenciaDate { get; set; }
    public List<AreaDto> ? Areas { get; set; }
    public List<LugarDto> ? Lugares { get; set; }
    public List<DetalleIncidenciaDto> ? DetalleIncidencias { get; set; }
}