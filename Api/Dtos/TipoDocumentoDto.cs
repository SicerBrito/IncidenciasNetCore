namespace ApiIncidencePro.Dtos;
public class TipoDocumentoDto
{
  public int TipoDocumentoId { get; set; }
  public string ? NombreTipoDocumento { get; set; }
  public List<TipoContactoDto> ? TipoContactos { get; set; }
  public List<UsuarioDto> ? Usuarios { get; set; }
}