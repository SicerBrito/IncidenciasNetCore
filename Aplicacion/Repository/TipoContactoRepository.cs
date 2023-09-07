using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;
public class TipoContactoRepository : TwoRepository<TipoContacto>, ITipoContacto
{
    private readonly SicerContext _Context;
    public TipoContactoRepository(SicerContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<TipoContacto>> GetAllAsync()
    {
        return await _Context.TipoDeContactos
                            .Include(a => a.Contactos)
                            .ToListAsync();
    }
}
