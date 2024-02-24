using APIAlmoxarigado.Infraestrutura;
using APIAlmoxarigado.Models;

namespace APIAlmoxarigado.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        ConexaoSQL bdConexao = new ConexaoSQL();

        public void Add(Produto produto)
        {
            bdConexao.Add(produto);
            bdConexao.SaveChanges();
        }

        public List<Produto> GetAll()
        {

            return bdConexao.Produto.ToList();
        }
    }
}
