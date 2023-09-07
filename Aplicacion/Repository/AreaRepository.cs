using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;
public class AreaRepository : GenericRepository<Area>, IArea
{
    private readonly SicerContext _Context;
    public AreaRepository(SicerContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<Area>> GetAllAsync()
    {
        return await _Context.Areas
                            .Include(a => a.AreaDeUsuarios)
                            .Include(a => a.Lugares)
                            .Include(a => a.Incidencias)
                            .ToListAsync();
    }
}
