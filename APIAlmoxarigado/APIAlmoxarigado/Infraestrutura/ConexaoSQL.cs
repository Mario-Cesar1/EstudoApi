using APIAlmoxarigado.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace APIAlmoxarigado.Infraestrutura
{
    public class ConexaoSQL : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
            =>
              optionBuilder.UseSqlServer(
                  @"Server=.\SENAI;" +
                  "Database=dbAlmoxarifado;" +
                  "User id=sa;" +
                  "Password=senai.123"


              );

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Requisicao>()
                .HasMany(e => e.itens)
                .WithOne(e => e.Requisicao)
                .HasForeignKey(e => e.CodigoRequisicao)
                .HasPrincipalKey(e => e.Codigo);


            modelBuilder.Entity<Produto>()
              .HasMany(e => e.itens)
              .WithOne(e => e.Produto)
              .HasForeignKey(e => e.CodigoProduto)
              .HasPrincipalKey(e => e.id);

            modelBuilder.Entity<CategoriaMotivo>()
              .HasMany(e => e.Motivos)
              .WithOne(e => e.CategoriaMotivo)
              .HasForeignKey(e => e.CAMID)
              .HasPrincipalKey(e => e.CAMID);
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<MotivoSaida> MotivoSaida { get; set; }
        public DbSet<CategoriaMotivo> CategoriaMotivo { get; set; }
        public DbSet<Requisicao> Requisicao { get; set; }
        public DbSet<itensRequisicao> ItensRequisicao { get; set; }
    }
}
