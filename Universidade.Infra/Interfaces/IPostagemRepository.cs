using Universidade.Domain;

namespace Universidade.Infra.Interfaces;

public interface IPostagemRepository 
{
    Task<List<Postagem>> GetAll();
    Task<Postagem> GetById(int id);
    Task<bool> Add(Postagem postagem);
    Task<bool> Update(int id, Postagem postagem);
    Task<bool> Delete(int id);

}