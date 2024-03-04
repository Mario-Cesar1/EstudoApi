using APIAlmoxarigado.Models;

namespace APIAlmoxarigado.Repository
{
    public interface IProdutoRepository
    {
        List<Produto> GetAll();

        void Delete(Produto idProduto);

        void Add(Produto produto);
        Task<Produto> GetById(int id);
        void Update(Produto produto);
    }
}
