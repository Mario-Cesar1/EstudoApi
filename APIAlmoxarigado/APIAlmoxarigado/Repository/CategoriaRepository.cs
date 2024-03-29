﻿using APIAlmoxarigado.Infraestrutura;
using APIAlmoxarigado.Models;

namespace APIAlmoxarigado.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        ConexaoSQL bdConexao = new ConexaoSQL();
        public void Add(Categoria categoria)
        {
            bdConexao.Add(categoria);
            bdConexao.SaveChanges();
        }

        public void Delete(Categoria Idcategoria)
        {
            bdConexao.Categoria.Remove(Idcategoria);
            bdConexao.SaveChanges();
        }

        public List<Categoria> GetAll()
        {
            return bdConexao.Categoria.ToList();
        } 
        public async Task<Categoria?> GetById(int id)
        {
            return await bdConexao.Set<Categoria>().FindAsync(id);
        }

        public void Update(Categoria categoria)
        {
            bdConexao.Categoria.Update(categoria);
            bdConexao.SaveChanges();
        }
    }
}
