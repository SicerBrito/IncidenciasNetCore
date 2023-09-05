namespace Dominio.Interfaces;
    public interface IUnitOfWork{
        INombreInterfas ? PluralInterfas { get; }
        Task<int> SaveAsync();
    }
