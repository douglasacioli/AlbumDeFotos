using Microsoft.EntityFrameworkCore;

namespace AlbumDeFotos.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            
        }

        public DbSet<Album> Albuns { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<UnidadeFuncional> UnidadesFuncionais { get; set; }
    }
}
