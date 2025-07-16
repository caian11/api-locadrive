using api_teste.Models;
using Microsoft.EntityFrameworkCore;

namespace api_teste.DataContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Locacao> Locacoes { get; set; } = null!;
        public DbSet<Veiculo> Veiculo { get; set; } = null!;
        public DbSet<Seguro> Seguros { get; set; } = null!;
        public DbSet<Endereco> Enderecos { get; set; } = null!;
        public DbSet<Pessoa> Pessoas { get; set; } = null!;
        public DbSet<Cidade> Cidades { get; set; } = null!;
        public DbSet<LocacaoVeiculo> LocacaoVeiculos { get; set; } = null!;
        public DbSet<LocacaoSeguro> LocacaoSeguros { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Locacao>()
                .ToTable("locacao")
                .HasKey(l => l.id);

            modelBuilder.Entity<Locacao>()
                .HasOne(l => l.Pessoa)
                .WithMany(p => p.locacoes)
                .HasForeignKey(l => l.PessoaId);

            modelBuilder.Entity<Veiculo>()
                .ToTable("veiculo")
                .HasKey(v => v.id);

            modelBuilder.Entity<Pessoa>()
                .ToTable("pessoa")
                .HasKey(p => p.Id);

            modelBuilder.Entity<Pessoa>()
                .HasOne(p => p.Endereco)
                .WithMany()
                .HasForeignKey(p => p.EnderecoId);

            modelBuilder.Entity<LocacaoVeiculo>()
                .ToTable("locacao_veiculo")
                .HasKey(lv => lv.Id);

            modelBuilder.Entity<LocacaoVeiculo>()
                .HasOne(lv => lv.Locacao)
                .WithMany(l => l.veiculos)
                .HasForeignKey(lv => lv.LocacaoId);

            modelBuilder.Entity<LocacaoVeiculo>()
                .HasOne(lv => lv.Veiculo)
                .WithMany(v => v.locacoes)
                .HasForeignKey(lv => lv.VeiculoId);

            modelBuilder.Entity<Seguro>()
                .ToTable("seguro")
                .HasKey(s => s.id);

            modelBuilder.Entity<LocacaoSeguro>()
                .ToTable("locacao_seguro")
                .HasKey(ls => ls.Id);

            modelBuilder.Entity<LocacaoSeguro>()
                .HasOne(ls => ls.Locacao)
                .WithMany(l => l.LocacaoSeguros)
                .HasForeignKey(ls => ls.LocacaoId);

            modelBuilder.Entity<LocacaoSeguro>()
                .HasOne(ls => ls.Seguro)
                .WithMany()
                .HasForeignKey(ls => ls.SeguroId);
        }
    }
}
