using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;
public class NivelIncidenciaRepository : TwoRepository<NivelIncidencia>, INivelIncidencia
{
    
    private readonly SicerContext _Context;
    public NivelIncidenciaRepository(SicerContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<NivelIncidencia>> GetAllAsync()
    {
        return await _Context.NivelDeIncidencias
                            .Include(a => a.DetalleDeIncidencias)
                            .ToListAsync();
    }
}
