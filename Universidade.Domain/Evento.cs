namespace Universidade.Domain;

public class Evento
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Location { get; set; }
    public string? Description { get; set; }
    
    public List<Usuario> Participantes { get; set; }
    public DateTime? DateTime { get; set; }
}