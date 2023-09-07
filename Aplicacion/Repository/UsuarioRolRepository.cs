using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;
public class UsuarioRolRepository : TwoRepository<UsuarioRol>, IUsuarioRol
{
    private readonly SicerContext _Context;
    public UsuarioRolRepository(SicerContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<UsuarioRol>> GetAllAsync()
    {
        return await _Context.UsuarioRols
                            .ToListAsync();
    }
}
