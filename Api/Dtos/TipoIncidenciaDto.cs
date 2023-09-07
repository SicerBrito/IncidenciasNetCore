namespace ApiIncidencePro.Dtos;
public class TipoIncidenciaDto
{
  public int TipoIncidenciaId { get; set; }
  public string ? NombreTipoIncidencia { get; set; }
  public string ? TipoIncidenciaDescription { get; set; }
  public List<DetalleIncidenciaDto> ? DetalleIncidencias { get; set; }
}