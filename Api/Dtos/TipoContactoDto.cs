namespace ApiIncidencePro.Dtos;
public class TipoContactoDto
{
  public int TipoContactoId { get; set; }
  public string ? NombreTipoContacto { get; set; }
  public string ? TipoContactoDescription { get; set; }
  public List<ContactoDto> ? Contactos { get; set; }

}