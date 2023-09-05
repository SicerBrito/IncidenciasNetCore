using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private INombreRepository? _NombreSingular;
    private readonly NameContext _Context;

    public UnitOfWork(NameContext context)=> _Context = context;
    
    public INombreRepository? NombrePlural => _NombreSingular ??= new NombreRepository(_Context);




    public void Dispose()
    {
        _Context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        return await _Context.SaveChangesAsync();
    }
}
