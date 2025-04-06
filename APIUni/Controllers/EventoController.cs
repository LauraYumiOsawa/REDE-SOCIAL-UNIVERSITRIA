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
        private readonly IEventoRepository _context;

        public EventosController(IEventoRepository context)
        {
            _context = context;
        }

        // GET: api/Eventos
        [HttpGet]
        public async Task<ActionResult<List<Evento>>> GetEventos()
        {
            var eventos = await _context.GetAll();
            return Ok(eventos); // Return 200 OK with the list of users
        }

        // GET: api/Eventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
            var evento = await _context.GetById(id);

            if (evento == null)
            {
                return NotFound(); // 404 Not Found if user doesn't exist
            }

            return Ok(evento); // Return 200 OK with the user
        }

        // POST: api/Eventos
        [HttpPost]
        public async Task<ActionResult<Evento>> PostEvento(Evento evento)
        {
            var isAdded = await _context.Add(evento);

            if (!isAdded)
            {
                return BadRequest("Erro ao adicionar o usuário."); // 400 Bad Request
            }

            return CreatedAtAction(nameof(GetEvento), new { id = evento.Id }, evento); // 201 Created
        }

        // DELETE: api/Eventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            var isDeleted = await _context.Delete(id);

            if (isDeleted)
            {
                return Ok("Usuário deletado com sucesso."); // 200 OK
            }

            return NotFound("Id não encontrado."); // 404 Not Found
        }
    }
}