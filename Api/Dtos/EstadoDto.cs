namespace ApiIncidencePro.Dtos;
public class EstadoDto
{
  public int EstadoId { get; set; }
  public string ? EstadoDescription { get; set; }
  public List<IncidenciaDto> ? Incidencias { get; set; }
  public List<DetalleIncidenciaDto> ? DetalleIncidencias { get; set; }
}