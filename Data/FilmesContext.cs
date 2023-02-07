using Microsoft.EntityFrameworkCore;
using Primeira_API.Models;

namespace Primeira_API.Data;

public class FilmesContext : DbContext
{
    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Endereco> Endereco { get; set; }
    public FilmesContext(DbContextOptions<FilmesContext> opts) : base(opts)
    {

    }
}
