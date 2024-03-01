using APIAlmoxarigado.Models;

namespace APIAlmoxarigado.Repository
{
    public interface IDepartamentoRepository
    {
        List<Departamento> GetAll();

        void Add(Departamento departamento);

        void Delete(Departamento idDepartamento);
    }
}
