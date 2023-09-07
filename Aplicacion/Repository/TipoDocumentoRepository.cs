using Aplicacion.Repository;
using Dominio;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;
public class TipoDocumentoRepository : GenericRepository<TipoDocumento>, ITipoDocumento
{
    private readonly SicerContext _Context;
    public TipoDocumentoRepository(SicerContext context) : base(context)
    {
        _Context = context;
    }
        public override async Task<IEnumerable<TipoDocumento>> GetAllAsync()
    {
        return await _Context.TipoDeDocumentos
                            .Include(a => a.Usuarios)
                            .ToListAsync();
    }
}
