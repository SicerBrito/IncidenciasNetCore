namespace ApiIncidencePro.Dtos;
public class DetalleIncidenciaDto
{
  public int DetalleIncidenciaId { get; set; }
  public string ? DetalleIncidenciaDescription { get; set; }
  public List<HerramientaTrabajoDto> ?HerramientaTrabajos { get; set; }
  public List<TipoIncidenciaDto> ? TipoIncidencias { get; set; }
  public List<NivelIncidenciaDto> ? NivelIncidencias { get; set; }
  public List<LugarDto> ? Lugares { get; set; }
}