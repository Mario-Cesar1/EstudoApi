using APIAlmoxarigado.Infraestrutura;
using APIAlmoxarigado.Models;

namespace APIAlmoxarigado.Repository
{
    public class RequisicaoRepository : IRequisicaoRepository
    {
        ConexaoSQL bdConexao = new ConexaoSQL();
        public void Add(Requisicao requisicao)
        {
            bdConexao.Requisicao.Add(requisicao);
            bdConexao.SaveChanges();
        }

        public void Delete(Requisicao idRequisicao)
        {
            bdConexao.Remove(idRequisicao);
            bdConexao.SaveChanges();
        }

        public List<Requisicao> GetAll()
        {
            return bdConexao.Set<Requisicao>().ToList();
        }

        public async Task<Requisicao> GetById(int id)
        {
            return await bdConexao.Set<Requisicao>().FindAsync(id);
        }

        public void Update(Requisicao requisicao)
        {
            bdConexao.Update(requisicao);
            bdConexao.SaveChanges();
        }
    }
}
