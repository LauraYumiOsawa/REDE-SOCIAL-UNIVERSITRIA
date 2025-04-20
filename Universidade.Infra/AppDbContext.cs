using Universidade.Domain;
using Microsoft.EntityFrameworkCore;

namespace Universidade.Infra;

public class AppDbContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Postagem> Postagens { get; set; }
    public DbSet<Evento> Eventos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseMySql("Server=localhost;Database=universidade_db;User=root;Password=minhasenha;",
            new MySqlServerVersion(new Version(8, 0, 32)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Followers ↔ Following
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Followers)
            .WithMany(u => u.Following)
            .UsingEntity<Dictionary<string, object>>(
                "UsuarioFollowers",
                j => j
                    .HasOne<Usuario>()
                    .WithMany()
                    .HasForeignKey("FollowerId")
                    .OnDelete(DeleteBehavior.Restrict),
                j => j
                    .HasOne<Usuario>()
                    .WithMany()
                    .HasForeignKey("FollowingId")
                    .OnDelete(DeleteBehavior.Cascade)
            );

        // Postagem → Author
        modelBuilder.Entity<Postagem>()
            .HasOne(p => p.Author)
            .WithMany(u => u.Postagens)
            .HasForeignKey(p => p.AuthorId);

        // Evento ↔ Participantes
        modelBuilder.Entity<Evento>()
            .HasMany(e => e.Participantes)
            .WithMany(u => u.Eventos);
    }
}