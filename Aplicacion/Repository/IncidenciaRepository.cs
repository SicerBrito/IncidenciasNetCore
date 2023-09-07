using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;
public class IncidenciaRepository : TwoRepository<Incidencia>, IIncidencia
{
    private readonly SicerContext _Context;
    public IncidenciaRepository(SicerContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<Incidencia>> GetAllAsync()
    {
        return await _Context.Incidencias
                            .Include(a => a.DetalleDeIncidencias)
                            .ToListAsync();
    }
}
