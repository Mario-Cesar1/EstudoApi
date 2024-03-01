using APIAlmoxarigado.Models;

namespace APIAlmoxarigado.Repository
{
    public interface IProdutoRepository
    {
        List<Produto> GetAll();

        void Delete(Produto idProduto);

        void Add(Produto produto);
    }
}
