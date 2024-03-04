using APIAlmoxarigado.Infraestrutura;
using APIAlmoxarigado.Models;

namespace APIAlmoxarigado.Repository
{
    public class CategoriaMotivoRepository : ICategoriaMotivoRepository
    {
        ConexaoSQL bdConexao = new ConexaoSQL();
        public void Add(CategoriaMotivo categoriaMotivo)
        {
            bdConexao.CategoriaMotivo.Add(categoriaMotivo);
            bdConexao.SaveChanges();
        }

        public void Delete(CategoriaMotivo idCatMotivo)
        {
            bdConexao.Remove(idCatMotivo);
            bdConexao.SaveChanges();
        }

        public List<CategoriaMotivo> GetAll()
        {
            return bdConexao.CategoriaMotivo.ToList();
        }

        public async Task<CategoriaMotivo> GetById(int id)
        {
            return await bdConexao.Set<CategoriaMotivo>().FindAsync(id);
        }

        public void Update(CategoriaMotivo categoriaMotivo)
        {
            bdConexao.Update(categoriaMotivo);
            bdConexao.SaveChanges();
        }
    }
}
