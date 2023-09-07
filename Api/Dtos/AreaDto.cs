using Dominio.Entities;

namespace ApiIncidencePro.Dtos;
public class AreaDto
{
  public int Pk_Id { get; set; }
  public string ? NombreArea { get; set; }
  public string ? AreaDescription { get; set; }
  public List<AreaUsuarioDto> ? AreaUsuarios { get; set; }  
  public List<LugarDto> ? Lugar { get; set; }  
  public List<IncidenciaDto> ? Incidencias { get; set; }  
}