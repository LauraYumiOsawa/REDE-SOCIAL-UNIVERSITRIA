using Universidade.Domain;
using Microsoft.EntityFrameworkCore;

using Universidade.Infra.Interfaces;

namespace Universidade.Infra.Repositories;

public class PostagemRepository : IPostagemRepository
{
    private readonly AppDbContext _context;

    public PostagemRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Postagem>> GetAll()
    {
        return await _context.Postagens.ToListAsync();
    }

    public async Task<Postagem> GetById(int id)
    {
        return await _context.Postagens.FindAsync(id);
    }
    
    public async Task<bool> Update(int id, Postagem postagem)
    {
        var postagemExistente = await _context.Postagens.FindAsync(id);
        if (postagemExistente == null) return false;

        postagemExistente.Author = postagem.Author;
        postagemExistente.Content = postagem.Content;
        postagemExistente.Likes = postagem.Likes;
        postagemExistente.DateTime = postagem.DateTime;
        
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Add(Postagem postagem)
    {
        if (postagem == null) return false;
        await _context.Postagens.AddAsync(postagem);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var postagem = await _context.Postagens.FindAsync(id);
        if (postagem == null) return false;

        _context.Postagens.Remove(postagem);
        await _context.SaveChangesAsync();
        return true;
    }
    
}