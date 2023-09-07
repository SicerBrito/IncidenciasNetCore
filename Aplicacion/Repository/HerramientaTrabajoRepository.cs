using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;
public class HerramientaTrabajoRepository : TwoRepository<HerramientaTrabajo>, IHerramientaTrabajo
{
    private readonly SicerContext _Context;
    public HerramientaTrabajoRepository(SicerContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<HerramientaTrabajo>> GetAllAsync() => await _Context.HerramientasDeTrabajo
                            .Include(a => a.DetalleDeIncidencias)
                            .ToListAsync();
}
