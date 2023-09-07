using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IUsuario : ITwoRepository<Usuario>{
        Task<Usuario> GetByUsernameAsync(string username);
    }
