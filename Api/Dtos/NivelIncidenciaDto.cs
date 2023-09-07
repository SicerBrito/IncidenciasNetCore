namespace ApiIncidencePro.Dtos;
public class NivelIncidenciaDto
{
  public int NivelIncidenciaId { get; set; }
  public string ? NombreNivelIncidencia { get; set; }
  public string ? NivelIncidenciaDescription { get; set; }
  public List<DetalleIncidenciaDto> ? DetalleIncidencias { get; set; }
}