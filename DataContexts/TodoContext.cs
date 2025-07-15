using api_teste.Models;
using Microsoft.EntityFrameworkCore;

namespace api_teste.DataContexts;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    //ADICIONAR AQUI OS MODELS E RELACIONAMENTOS
    public DbSet<Veiculo> Veiculo { get; set; } = null!;
    public DbSet<Pessoa> Pessoas { get; set; } = null!;
    public DbSet<Endereco> Enderecos { get; set; } = null!;

    public DbSet<Seguro> Seguros { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pessoa>()
            .HasMany(p => p.Endereco)
            .WithMany(e => e.Filmes)
            .HasForeignKey(e => e.EstudioId)
            .IsRequired(false);

        modelBuilder.Entity<Filme>()
            .HasMany(e => e.Generos)
            .WithMany(e => e.Filmes)
            .UsingEntity(
                "filmes_generos",
                r => r.HasOne(typeof(Genero)).WithMany().HasForeignKey("genero_id").HasPrincipalKey(nameof(Genero.Id)),
                l => l.HasOne(typeof(Filme)).WithMany().HasForeignKey("filme_id").HasPrincipalKey(nameof(Filme.Id)),
                j => j.HasKey("filme_id", "genero_id"));

    }
}