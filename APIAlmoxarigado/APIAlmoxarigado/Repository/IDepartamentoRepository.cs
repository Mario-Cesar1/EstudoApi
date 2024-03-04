using APIAlmoxarigado.Models;

namespace APIAlmoxarigado.Repository
{
    public interface IDepartamentoRepository
    {
        List<Departamento> GetAll();

        void Add(Departamento departamento);

        void Delete(Departamento idDepartamento);

        Task<Departamento> GetById(int id);

        void Update(Departamento departamento);
    }
}
