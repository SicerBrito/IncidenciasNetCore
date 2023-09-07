using Aplicacion.Repository;
using Dominio;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private AreaRepository? _Areas;
    private AreaUsuarioRepository? _AreaUsuarios;
    private ContactoRepository? _Contactos;
    private DetalleIncidenciaRepository? _DetalleIncidencia;
    private DireccionRepository? _Direccion;
    private HerramientaTrabajoRepository _HerramientaTrabajos;
    private IncidenciaRepository? _Incidencias;
    private LugarRepository? _Lugar;
    private NivelIncidenciaRepository? _NivelIncidencia;
    private RolRepository? _Roles;
    private TipoContactoRepository? _TipoContacto;
    private TipoDocumentoRepository? _TipoDocumento;
    private TipoIncidenciaRepository? _TipoIncidencias;
    private TipoViaRepository? _TipoVia;
    private UsuarioRepository? _Usuario;
    private UsuarioRolRepository? _UsuarioRol;

    private readonly SicerContext _Context;

    public UnitOfWork(SicerContext context)=> _Context = context;
    
    // public INombreRepository? NombrePlural => _NombreSingular ??= new NombreRepository(_Context);

    public IArea? Areas => _Areas ??= new AreaRepository(_Context);

    public IAreaUsuario? AreasUsuarios => _AreaUsuarios ??= new AreaUsuarioRepository(_Context);

    public IContacto? Contactos => _Contactos ??= new ContactoRepository(_Context);

    public IDetalleIncidencia? DetalleIncidencias => _DetalleIncidencia ??= new DetalleIncidenciaRepository(_Context);

    public IDireccion? Direcciones => _Direccion ??= new DireccionRepository(_Context);

    public IHerramientaTrabajo? HerramientaTrabajos => _HerramientaTrabajos ??= new HerramientaTrabajoRepository(_Context);

    public IIncidencia? Incidencias => _Incidencias ??= new IncidenciaRepository(_Context);

    public ILugar? Lugares => _Lugar ??= new LugarRepository(_Context);

    public INivelIncidencia? NivelIncidencias => _NivelIncidencia ??= new NivelIncidenciaRepository(_Context);

    public IRol? Roles => _Roles ??= new RolRepository(_Context);

    public ITipoContacto? TipoContactos => _TipoContacto ??= new TipoContactoRepository(_Context);
    public ITipoDocumento? TipoDocumentos => _TipoDocumento ??= new TipoDocumentoRepository(_Context);
    public ITipoIncidencia? TipoIncidencias => _TipoIncidencias ??= new TipoIncidenciaRepository(_Context);

    public ITipoVia? TipoVias => _TipoVia ??= new TipoViaRepository(_Context);

    public IUsuario? Usuarios => _Usuario ??= new UsuarioRepository(_Context);

    public IUsuarioRol? UsuarioRoles => _UsuarioRol ??= new UsuarioRolRepository(_Context);

    public virtual  void Dispose()
    {
        _Context.Dispose();
        GC.SuppressFinalize(this); 
    }

    public async Task<int> SaveAsync()
    {
        return await _Context.SaveChangesAsync();
    }
}
