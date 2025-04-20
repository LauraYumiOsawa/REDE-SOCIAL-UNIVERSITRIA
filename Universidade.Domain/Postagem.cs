namespace Universidade.Domain;

public class Postagem
{
    public int Id { get; set; }
    
    public int AuthorId { get; set; }
    public Usuario Author { get; set; }
    
    public int? Likes { get; set; }
    public string? Content { get; set; }
    public DateTime? DateTime { get; set; }
}