namespace ApiIncidencePro.Dtos;
public class ContactoDto
{
  public int ContactoId { get; set; }
  public string ? ContactoDescription { get; set; }
  public List<UsuarioDto> ? Usuarios { get; set; } 
  public List<TipoContactoDto> ? TipoContacto { get; set; }
}