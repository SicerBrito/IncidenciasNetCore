namespace ApiIncidencePro.Dtos;
public class AreaUsuarioDto
{
  public int AreaUsuarioId { get; set; }
  public List<UsuarioDto> ? Usuraios { get; set; }  
  public List<AreaDto> ? Areas { get; set; }  
}