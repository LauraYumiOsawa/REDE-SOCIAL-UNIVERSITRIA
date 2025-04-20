namespace Universidade.Domain.Services
{
    public class EventoDomainService
    {
        public bool PodeParticipar(Evento evento, Usuario usuario)
        {
            if (evento.Participantes.Any(p => p.Id == usuario.Id))
                return false;

            if (evento.Participantes.Count >= 50)
                return false;

            return true;
        }
    }
}