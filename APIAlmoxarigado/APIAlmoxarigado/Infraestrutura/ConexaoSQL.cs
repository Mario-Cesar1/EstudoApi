﻿using APIAlmoxarigado.Models;
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
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<MotivoSaida> MotivoSaida { get; set; }
        public DbSet<CategoriaMotivo> CategoriaMotivo { get; set; }
        public DbSet<Requisicao> Requisicao { get; set; }
    }
}
