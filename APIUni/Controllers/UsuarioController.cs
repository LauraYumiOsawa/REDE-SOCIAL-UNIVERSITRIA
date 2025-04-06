using Universidade.Domain;
using Universidade.Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Universidade.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _context;

        public UsuariosController(IUsuarioRepository context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetUsuarios()
        {
            var usuarios = await _context.GetAll();
            return Ok(usuarios); // Return 200 OK with the list of users
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.GetById(id);

            if (usuario == null)
            {
                return NotFound(); // 404 Not Found if user doesn't exist
            }

            return Ok(usuario); // Return 200 OK with the user
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            var isAdded = await _context.Add(usuario);

            if (!isAdded)
            {
                return BadRequest("Erro ao adicionar o usuário."); // 400 Bad Request
            }

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario); // 201 Created
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
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