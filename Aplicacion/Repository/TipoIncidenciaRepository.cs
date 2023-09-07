using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class TipoIncidenciaRepository : TwoRepository<TipoIncidencia>, ITipoIncidencia
{
    private readonly SicerContext _Context;
    public TipoIncidenciaRepository(SicerContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<TipoIncidencia>> GetAllAsync()
    {
        return await _Context.TipoDeIncidencias
                            .Include(a => a.DetalleDeIncidencias)
                            .ToListAsync();
    }
}
