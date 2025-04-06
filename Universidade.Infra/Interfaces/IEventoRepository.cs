using Universidade.Domain;

namespace Universidade.Infra.Interfaces;

public interface IEventoRepository 
{
    Task<List<Evento>> GetAll();
    Task<Evento> GetById(int id);
    Task<bool> Add(Evento evento);
    Task<bool> Update(int id, Evento evento);
    Task<bool> Delete(int id);

}