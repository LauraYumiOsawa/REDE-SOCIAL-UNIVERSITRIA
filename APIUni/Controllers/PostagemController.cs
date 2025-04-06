using Universidade.Domain;
using Universidade.Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Universidade.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostagensController : ControllerBase
    {
        private readonly IPostagemRepository _context;

        public PostagensController(IPostagemRepository context)
        {
            _context = context;
        }

        // GET: api/Postagens
        [HttpGet]
        public async Task<ActionResult<List<Postagem>>> GetPostagens()
        {
            var postagens = await _context.GetAll();
            return Ok(postagens); // Return 200 OK with the list of users
        }

        // GET: api/Postagens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Postagem>> GetPostagem(int id)
        {
            var postagem = await _context.GetById(id);

            if (postagem == null)
            {
                return NotFound(); // 404 Not Found if user doesn't exist
            }

            return Ok(postagem); // Return 200 OK with the user
        }

        // POST: api/Postagens
        [HttpPost]
        public async Task<ActionResult<Postagem>> PostPostagem(Postagem postagem)
        {
            var isAdded = await _context.Add(postagem);

            if (!isAdded)
            {
                return BadRequest("Erro ao adicionar o usuário."); // 400 Bad Request
            }

            return CreatedAtAction(nameof(GetPostagem), new { id = postagem.Id }, postagem); // 201 Created
        }

        // DELETE: api/Postagens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostagem(int id)
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