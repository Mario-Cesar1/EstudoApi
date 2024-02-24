using APIAlmoxarigado.Models;
using Microsoft.EntityFrameworkCore;

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

        public DbSet<Produto> Produto { get; set; }
    }
}
