using APIAlmoxarigado.Models;

namespace APIAlmoxarigado.Repository
{
    public interface IEntradaRepositorycs
    {
        List<Entrada> GetAll();

        void Add(Entrada entrada);

        void Delete(Entrada idEntrada);

        Task<Entrada> GetById(int id);
        void Update(Entrada entrada);
    }
}
