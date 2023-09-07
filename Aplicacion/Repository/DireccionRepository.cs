using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;
public class DireccionRepository : GenericRepository<Direccion>, IDireccion
{
    private readonly SicerContext _Context;
    public DireccionRepository(SicerContext context) : base(context)
    {
        _Context = context;
    }

    public override async Task<IEnumerable<Direccion>> GetAllAsync()
    {
        return await _Context.Direcciones
                            .ToListAsync();
    }
}
