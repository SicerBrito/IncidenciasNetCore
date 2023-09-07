using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;
public class AreaUsuarioRepository : TwoRepository<AreaUsuario>, IAreaUsuario
{
    private readonly SicerContext _Context;
    public AreaUsuarioRepository(SicerContext context) : base(context)
    {
        _Context = context;
    }

    public override async Task<IEnumerable<AreaUsuario>> GetAllAsync()
    {
        return await _Context.AreaUsuarios
                            .ToListAsync();
    }
}
