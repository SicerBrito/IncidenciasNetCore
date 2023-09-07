namespace ApiIncidencePro.Dtos;
public class HerramientaTrabajoDto
{
  public int HerramientaTrabajo { get; set; }
  public string ? NombreHerramientaTrabajo { get; set; }
  public List<DetalleIncidenciaDto> ? DetalleIncidencias { get; set; }
}