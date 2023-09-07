using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;
public class ContactoRepository : TwoRepository<Contacto>, IContacto
{
    private readonly SicerContext _Context;
    public ContactoRepository(SicerContext context) : base(context)
    {
        _Context = context;
    }

    public override async Task<IEnumerable<Contacto>> GetAllAsync()
    {
        return await _Context.Contactos
                            .ToListAsync();
    }

}
