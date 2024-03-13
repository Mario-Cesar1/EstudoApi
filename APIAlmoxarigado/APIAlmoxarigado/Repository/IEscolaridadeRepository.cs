using APIAlmoxarigado.Models;

namespace APIAlmoxarigado.Repository
{
    public interface IEscolaridadeRepository
    {
        List<Escolaridade> GetAll();

        void Add(Escolaridade escolaridade);

        void Delete(Escolaridade idEscolaridade);

        Task<Escolaridade> GetById(int id);
        void Update(Escolaridade escolaridade);
    }
}
