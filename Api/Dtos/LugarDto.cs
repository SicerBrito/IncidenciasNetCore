namespace ApiIncidencePro.Dtos;
public class LugarDto
{
  public int LugarId { get; set; }
  public string ? NombreLugar { get; set; }
  public string ? LugarDescription { get; set; }
  public List<AreaDto> ? Areas { get; set; }
  public List<IncidenciaDto> ? Incidencias { get; set; }
}