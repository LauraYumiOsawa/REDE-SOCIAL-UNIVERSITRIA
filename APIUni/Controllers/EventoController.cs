using Universidade.Domain;
using Universidade.Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Universidade.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly IEventoRepository _eventoRepository;

        public EventosController(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        // GET: api/Eventos
        [HttpGet]
        public async Task<ActionResult<List<Evento>>> GetEventos()
        {
            var eventos = await _eventoRepository.GetAll();
            return Ok(eventos); 
        }

        // GET: api/Eventos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
            var evento = await _eventoRepository.GetById(id);

            if (evento == null)
                return NotFound("Evento não encontrado.");

            return Ok(evento);
        }

        // POST: api/Eventos
        [HttpPost]
        public async Task<ActionResult<Evento>> PostEvento([FromBody] Evento evento)
        {
            var isAdded = await _eventoRepository.Add(evento);

            if (!isAdded)
                return BadRequest("Erro ao adicionar o evento.");

            return CreatedAtAction(nameof(GetEvento), new { id = evento.Id }, evento);
        }
        
        // POST: api/eventos/{eventoId}/inscrever/{usuarioId}
        [HttpPost("{eventoId}/inscrever/{usuarioId}")]
        public async Task<IActionResult> InscreverUsuario(Guid eventoId, int usuarioId)
        {
            var sucesso = await _eventoRepository.InscreverUsuario(eventoId, usuarioId);

            if (!sucesso)
                return BadRequest("Não foi possível inscrever o usuário. Verifique se ele já está inscrito ou se o evento está cheio.");

            return Ok("Usuário inscrito com sucesso.");
        }


        // DELETE: api/Eventos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            var isDeleted = await _eventoRepository.Delete(id);

            if (!isDeleted)
                return NotFound("Evento não encontrado.");

            return Ok("Evento deletado com sucesso.");
        }
    }
}