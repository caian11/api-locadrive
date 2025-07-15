using Microsoft.EntityFrameworkCore;

namespace api_teste.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    //ADICIONAR AQUI AS ENTIDADES DO BD
    public DbSet<Veiculo> Veiculo { get; set; } = null!;
    public DbSet<Seguro> Seguros { get; set; } = null!;
    public DbSet<Locacao> Locacoes { get; set; } = null!;
    public DbSet<LocacaoVeiculo> LocacaoVeiculos { get; set; } = null!;
}