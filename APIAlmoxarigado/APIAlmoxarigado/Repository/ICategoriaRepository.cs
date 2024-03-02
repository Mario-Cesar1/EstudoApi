using APIAlmoxarigado.Models;

namespace APIAlmoxarigado.Repository
{
    public interface ICategoriaRepository
    {
        List<Categoria> GetAll();

        void Add(Categoria categoria);

        void Delete(Categoria Idcategoria);

        Task<Categoria> GetById(int id);
    }
}
