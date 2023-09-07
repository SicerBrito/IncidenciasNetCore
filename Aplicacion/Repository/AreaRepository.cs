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
                            .Include(a => a.AreaUsuarios)
                            .Include(a => a.Lugar)
                            .Include(a => a.Incidencia)
                            .ToListAsync();
    }
}
