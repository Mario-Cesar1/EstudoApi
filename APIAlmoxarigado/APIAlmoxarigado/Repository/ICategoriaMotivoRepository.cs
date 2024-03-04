using APIAlmoxarigado.Models;

namespace APIAlmoxarigado.Repository
{
    public interface ICategoriaMotivoRepository
    {
        List<CategoriaMotivo> GetAll();

        void Add(CategoriaMotivo categoriaMotivo);

        void Delete(CategoriaMotivo idCatMotivo);

        Task<CategoriaMotivo> GetById(int id);
        void Update(CategoriaMotivo categoriaMotivo);
    }
}
