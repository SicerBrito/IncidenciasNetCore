using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;
public class LugarRepository : TwoRepository<Lugar>, ILugar
{
    private readonly SicerContext _Context;
    public LugarRepository(SicerContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<Lugar>> GetAllAsync()
    {
        return await _Context.Lugares
                            .Include(a => a.Incidencias)
                            .ToListAsync();
    }
}
