using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;
public class TipoViaRepository : TwoRepository<TipoVia>, ITipoVia
{
    private readonly SicerContext _Context;
    public TipoViaRepository(SicerContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<TipoVia>> GetAllAsync()
    {
        return await _Context.TipoDeVias
                            .ToListAsync();
    }
}
