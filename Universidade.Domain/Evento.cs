namespace Universidade.Domain;

public class Evento
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string? Location { get; set; }
    public string? Description { get; set; }
    public DateTime? DateTime { get; set; }

    public bool TemLimite { get; set; }
    public int LimiteParticipantes { get; set; }

    public ICollection<Usuario> Participantes { get; set; } = new List<Usuario>();
}