using APIAlmoxarigado.Infraestrutura;
using APIAlmoxarigado.Models;

namespace APIAlmoxarigado.Repository
{
    public class MotivoSaidaRepository : IMotivoSaidaRepository
    {
        ConexaoSQL conexaobd = new ConexaoSQL();
        public void Add(MotivoSaida funcionario)
        {
            conexaobd.Add(funcionario);
            conexaobd.SaveChanges();
        }

        public void Delete(MotivoSaida idFuncionario)
        {
            conexaobd.Remove(idFuncionario);
            conexaobd.SaveChanges();
        }

        public List<MotivoSaida> GetAll()
        {
            return conexaobd.MotivoSaida.ToList();
        }

        public async Task<MotivoSaida> GetById(int id)
        {
            return await conexaobd.Set<MotivoSaida>().FindAsync(id);
        }

        public void Update(MotivoSaida funcionario)
        {
            conexaobd.Update(funcionario);
            conexaobd.SaveChanges();
        }
    }
}
