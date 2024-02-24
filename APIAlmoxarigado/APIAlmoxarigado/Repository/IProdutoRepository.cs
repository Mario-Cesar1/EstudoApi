using APIAlmoxarigado.Models;

namespace APIAlmoxarigado.Repository
{
    public interface IProdutoRepository
    {
        List<Produto> GetAll();

        void Add(Produto produto);
    }
}
