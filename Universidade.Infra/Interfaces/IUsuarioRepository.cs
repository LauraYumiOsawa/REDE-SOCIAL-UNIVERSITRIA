using Universidade.Domain;

namespace Universidade.Infra.Interfaces;

public interface IUsuarioRepository 
{
    Task<List<Usuario>> GetAll();
    Task<Usuario> GetById(int id);
    Task<bool> Add(Usuario usuario);
    Task<bool> Update(int id, Usuario usuario);
    Task<bool> Delete(int id);

}