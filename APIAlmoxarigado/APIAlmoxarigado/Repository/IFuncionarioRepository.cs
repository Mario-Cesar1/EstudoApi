using APIAlmoxarigado.Models;

namespace APIAlmoxarigado.Repository
{
    public interface IFuncionarioRepository
    {
        List<Funcionario> GetAll();

        void Add(Funcionario funcionario);

        void Delete(Funcionario idFuncionario);

        Task<Funcionario> GetById(int id);
    }
}
