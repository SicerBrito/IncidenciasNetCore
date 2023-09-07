using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;
public class DetalleIncidenciaRepository : TwoRepository<DetalleIncidencia>, IDetalleIncidencia
{
    private readonly SicerContext _Context;
    public DetalleIncidenciaRepository(SicerContext context) : base(context)
    {
        _Context = context;
    }

    public override async Task<IEnumerable<DetalleIncidencia>> GetAllAsync()
    {
        return await _Context.DetalleDeIncidencias
                            .ToListAsync();
    }
    
}
