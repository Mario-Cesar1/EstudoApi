using APIAlmoxarigado.Models;

namespace APIAlmoxarigado.Repository
{
    public interface IRequisicaoRepository
    {
        List<Requisicao> GetAll();

        void Add(Requisicao requisicao);

        void Delete(Requisicao idRequisicao);

        Task<Requisicao> GetById(int id);
        void Update(Requisicao requisicao);
    }
}
