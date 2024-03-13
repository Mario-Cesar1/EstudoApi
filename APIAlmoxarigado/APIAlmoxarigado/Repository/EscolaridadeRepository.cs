using APIAlmoxarigado.Infraestrutura;
using APIAlmoxarigado.Models;

namespace APIAlmoxarigado.Repository
{
    public class EscolaridadeRepository : IEscolaridadeRepository
    {
        ConexaoSQL Dbconexao = new ConexaoSQL();

        public void Add(Escolaridade escolaridade)
        {
            Dbconexao.Escolaridade.Add(escolaridade);
            Dbconexao.SaveChanges();
        }

        public void Delete(Escolaridade idEscolaridade)
        {
            Dbconexao.Escolaridade.Remove(idEscolaridade);
            Dbconexao.SaveChanges();
        }

        public List<Escolaridade> GetAll()
        {
            return Dbconexao.Escolaridade.ToList();
        }

        public async Task<Escolaridade> GetById(int id)
        {
            return await Dbconexao.Set<Escolaridade>().FindAsync(id);
        }

        public void Update(Escolaridade escolaridade)
        {
            Dbconexao.Escolaridade.Update(escolaridade);
            Dbconexao.SaveChanges();
        }
    }
}
