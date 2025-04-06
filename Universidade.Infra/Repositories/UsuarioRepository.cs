using Universidade.Domain;
using Microsoft.EntityFrameworkCore;

using Universidade.Infra.Interfaces;

namespace Universidade.Infra.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Usuario>> GetAll()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<Usuario> GetById(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }
    
    public async Task<bool> Update(int id, Usuario usuario)
    {
        var usuarioExistente = await _context.Usuarios.FindAsync(id);
        if (usuarioExistente == null) return false;

        usuarioExistente.Name = usuario.Name;
        usuarioExistente.Email = usuario.Email;
        usuarioExistente.Course = usuario.Course;
        usuarioExistente.Followers = usuario.Followers;
        usuarioExistente.Enrollment = usuario.Enrollment;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Add(Usuario usuario)
    {
        if (usuario == null) return false;
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null) return false;

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
        return true;
    }
    
}