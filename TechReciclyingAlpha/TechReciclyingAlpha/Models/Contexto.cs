using Microsoft.EntityFrameworkCore;

namespace TechReciclyingAlpha.Models
{
    public class Contexto : DbContext 
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<Ecoponto> Ecoponto { get; set; }

        public DbSet<Usuario> Usuario { get; set; } 

    }
}
