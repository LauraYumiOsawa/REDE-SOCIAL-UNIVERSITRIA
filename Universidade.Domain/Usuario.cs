
namespace Universidade.Domain;

public class Usuario
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Course { get; set; }
    public List<Usuario> Followers { get; set; }
    public string? Enrollment { get; set; }
}