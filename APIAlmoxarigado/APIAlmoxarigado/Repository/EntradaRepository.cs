using APIAlmoxarigado.Infraestrutura;
using APIAlmoxarigado.Models;

namespace APIAlmoxarigado.Repository
{
    public class EntradaRepository : IEntradaRepositorycs
    {
        ConexaoSQL bdConexao = new ConexaoSQL();
        public void Add(Entrada entrada)
        {
            bdConexao.Entrada.Add(entrada);
            bdConexao.SaveChanges();
        }

        public void Delete(Entrada idEntrada)
        {
            bdConexao.Entrada.Remove(idEntrada);
            bdConexao.SaveChanges();
        }

        public List<Entrada> GetAll()
        {
            return bdConexao.Entrada.ToList();
        }

        public async Task<Entrada> GetById(int id)
        {
            return await bdConexao.Set<Entrada>().FindAsync(id);
        }

        public void Update(Entrada entrada)
        {
            bdConexao.Entrada.Update(entrada);
            bdConexao.SaveChanges();
        }
    }
}
