namespace Dominio.Interfaces;
    public interface IUnitOfWork{
        IArea ? Areas { get; }
        IAreaUsuario ? AreaUsuarios { get;}
        IContacto ? Contactos { get; }
        IDetalleIncidencia ? DetalleIncidencias { get; }
        IDireccion ? Direcciones { get; }
        IHerramientaTrabajo ? HerramientaTrabajos { get; }
        IIncidencia ? Incidencias { get; }
        ILugar ? Lugares { get; }
        INivelIncidencia ? NivelIncidencias { get; }
        IRol ? Roles { get; }
        ITipoContacto ? TipoContactos { get; }
        ITipoDocumento ? TipoDocumentos { get; }
        ITipoIncidencia ? TipoIncidencias { get; }
        ITipoVia ? TipoVias { get; }
        IUsuario? Usuarios { get; }
        IUsuarioRol ? UsuarioRoles { get; }
        Task<int> SaveAsync();
    }
