using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Universidade.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Course { get; set; }

        public ICollection<Usuario> Followers { get; set; } = new List<Usuario>();
        public ICollection<Usuario> Following { get; set; } = new List<Usuario>();
        public ICollection<Postagem> Postagens { get; set; } = new List<Postagem>();
        public ICollection<Evento> Eventos { get; set; } = new List<Evento>();
        public string Enrollment { get; set; }
    }
}