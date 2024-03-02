using APIAlmoxarigado.Infraestrutura;
using APIAlmoxarigado.Models;

namespace APIAlmoxarigado.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        ConexaoSQL bdConexao = new ConexaoSQL();

        public void Add(Funcionario funcionario)
        {
            bdConexao.Add(funcionario);
            bdConexao.SaveChanges();
        }

        public void Delete(Funcionario idFuncionario)
        {
            bdConexao.Funcionario.Remove(idFuncionario);
            bdConexao.SaveChanges();
        }

        public List<Funcionario> GetAll()
        {

            return bdConexao.Funcionario.ToList();
        }

        public async Task<Funcionario?> GetById(int id)
        {
            return await bdConexao.Set<Funcionario>().FindAsync(id);
        }
    }
}
