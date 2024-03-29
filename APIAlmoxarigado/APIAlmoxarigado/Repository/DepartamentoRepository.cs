﻿using APIAlmoxarigado.Infraestrutura;
using APIAlmoxarigado.Models;

namespace APIAlmoxarigado.Repository
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        ConexaoSQL bdConexao = new ConexaoSQL();
        public void Add(Departamento departamento)
        {
            bdConexao.Add(departamento);
            bdConexao.SaveChanges();
        }

        public void Delete(Departamento idDepartamento)
        {
            bdConexao.Departamento.Remove(idDepartamento);
            bdConexao.SaveChanges();
        }

        public List<Departamento> GetAll()
        {
            return bdConexao.Departamento.ToList();
        }

        public async Task<Departamento?> GetById(int id)
        {
            return await bdConexao.Set<Departamento>().FindAsync(id);
        }
        public void Update(Departamento departamento)
        {
            bdConexao.Departamento.Update(departamento);
            bdConexao.SaveChanges();
        }
    }
}
