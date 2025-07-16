using api_teste.Models;
using Microsoft.EntityFrameworkCore;

namespace api_teste.DataContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Locacao> Locacoes { get; set; } = null!;
        public DbSet<Veiculo> Veiculo { get; set; } = null!;
        public DbSet<Seguro> Seguros { get; set; }
        public DbSet<Endereco> Enderecos { get; set; } = null!;
        public DbSet<Pessoa> Pessoas { get; set; } = null!;
        public DbSet<Cidade> Cidades { get; set; } = null!;
        public DbSet<LocacaoVeiculo> LocacaoVeiculos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tabela locacao_veiculo com dados adicionais (não usa UsingEntity)
            modelBuilder.Entity<LocacaoVeiculo>()
                .ToTable("locacao_veiculo")
                .HasKey(lv => lv.id);

            modelBuilder.Entity<LocacaoVeiculo>()
                .HasOne(lv => lv.Locacao)
                .WithMany(l => l.veiculos)
                .HasForeignKey(lv => lv.locacao);

            modelBuilder.Entity<LocacaoVeiculo>()
                .HasOne(lv => lv.Veiculo)
                .WithMany(v => v.locacoes)
                .HasForeignKey(lv => lv.veiculo);

            // Tabela locacao
            modelBuilder.Entity<Locacao>()
                .ToTable("locacao")
                .HasKey(l => l.id);

            modelBuilder.Entity<Locacao>()
                .HasOne(l => l.Pessoa)
                .WithMany(p => p.locacoes)
                .HasForeignKey(l => l.pessoa);

            // Tabela veiculo
            modelBuilder.Entity<Veiculo>()
                .ToTable("veiculo")
                .HasKey(v => v.id);

            // Tabela pessoa
            modelBuilder.Entity<Pessoa>()
                .ToTable("pessoa")
                .HasKey(p => p.Id);
        }
    }
}
