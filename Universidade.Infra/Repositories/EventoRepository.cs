using Universidade.Domain;
using Microsoft.EntityFrameworkCore;

using Universidade.Infra.Interfaces;

namespace Universidade.Infra.Repositories;

public class EventoRepository : IEventoRepository
{
    private readonly AppDbContext _context;

    public EventoRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Evento>> GetAll()
    {
        return await _context.Eventos.ToListAsync();
    }

    public async Task<Evento> GetById(int id)
    {
        return await _context.Eventos.FindAsync(id);
    }
    
    public async Task<bool> Update(int id, Evento evento)
    {
        var eventoExistente = await _context.Eventos.FindAsync(id);
        if (eventoExistente == null) return false;

        eventoExistente.Name = evento.Name;
        eventoExistente.Location = evento.Location;
        eventoExistente.Description = evento.Description;
        eventoExistente.DateTime = evento.DateTime;
        
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Add(Evento evento)
    {
        if (evento == null) return false;
        await _context.Eventos.AddAsync(evento);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var evento = await _context.Eventos.FindAsync(id);
        if (evento == null) return false;

        _context.Eventos.Remove(evento);
        await _context.SaveChangesAsync();
        return true;
    }
    
}