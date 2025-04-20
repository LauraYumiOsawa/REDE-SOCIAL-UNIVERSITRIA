using Universidade.Domain;

namespace Universidade.Infra.Interfaces
{
    public interface IEventoRepository
    {
        Task<Evento?> ObterPorIdComParticipantesAsync(Guid eventoId);
        Task<List<Evento>> GetAll();
        Task<Evento> GetById(int id);
        Task<bool> Add(Evento evento);
        Task SalvarAsync();
        Task<bool> InscreverUsuario(Guid eventoId, int usuarioId);
        Task<bool> Update(int id, Evento evento);
        Task<bool> Delete(int id);
    }
}