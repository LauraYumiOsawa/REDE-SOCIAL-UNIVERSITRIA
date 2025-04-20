using Universidade.Domain;
using Universidade.Infra;
using Universidade.Infra.Repositories;
using Universidade.Domain.Services;
using Universidade.Infra.Interfaces;

namespace Universidade.Application.ApplicationServices
{
    public class EventoAppService
    {
        private readonly IEventoRepository _eventoRepo;
        private readonly EventoDomainService _domainService;

        public EventoAppService(IEventoRepository eventoRepo, EventoDomainService domainService)
        {
            _eventoRepo = eventoRepo;
            _domainService = domainService;
        }

        public async Task<bool> InscreverUsuarioAsync(Guid eventoId, Usuario usuario)
        {
            var evento = await _eventoRepo.ObterPorIdComParticipantesAsync(eventoId);

            if (evento == null || usuario == null)
                return false;

            if (!_domainService.PodeParticipar(evento, usuario))
                return false;

            evento.Participantes.Add(usuario);
            await _eventoRepo.SalvarAsync();

            return true;
        }
    }
}