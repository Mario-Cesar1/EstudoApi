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
            return bdConexao.Set<Funcionario>().ToList();
        }

        public async Task<Funcionario?> GetById(int id)
        {
            return await bdConexao.Set<Funcionario>().FindAsync(id);
        }

        public void Update(Funcionario funcionario)
        {
            bdConexao.Funcionario.Update(funcionario);
            bdConexao.SaveChanges();
        }
    }
}
