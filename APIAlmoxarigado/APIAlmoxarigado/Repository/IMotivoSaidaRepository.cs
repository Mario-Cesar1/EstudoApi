using APIAlmoxarigado.Models;

namespace APIAlmoxarigado.Repository
{
    public interface IMotivoSaidaRepository
    {
        List<MotivoSaida> GetAll();

        void Add(MotivoSaida motivoSaida);

        void Delete(MotivoSaida idMotSaida);

        Task<MotivoSaida> GetById(int id);
        void Update(MotivoSaida motivoSaida);
    }
}
