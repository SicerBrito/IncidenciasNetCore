using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;
public class UsuarioRepository : TwoRepository<Usuario>, IUsuario
{
    private readonly SicerContext _Context;
    public UsuarioRepository(SicerContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await _Context.Usuarios
                            .Include(a => a.Incidencias)
                            .Include(a => a.Contactos)
                            .Include(a => a.AreaDeUsuarios)
                            .Include(a => a.Roles)
                            .Include(a => a.Incidencias)
                            .Include(a => a.Direcciones)
                            .ToListAsync();
    }

    public async Task<Usuario> GetByUsernameAsync(string username)
    {
        return (await _Context.Set<Usuario>()
                                    .Include(u => u.Roles)
                                    .FirstOrDefaultAsync(u => u.Nombres!.ToLower() == username.ToLower()))!;
    }

}
