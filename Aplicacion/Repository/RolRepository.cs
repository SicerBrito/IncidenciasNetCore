using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;
public class RolRepository : TwoRepository<Rol>, IRol
{
    private readonly SicerContext _Context;
    public RolRepository(SicerContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<Rol>> GetAllAsync()
    {
        return await _Context.Rols
                            .Include(a => a.Usuarios)
                            .ToListAsync();
    }
}
