using APIAlmoxarigado.Models;
using APIAlmoxarigado.Repository;
using APIAlmoxarigado.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace APIAlmoxarigado.Controllers
{
    [ApiController]
    [Route("api/v1/funcionario")]
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioController(IFuncionarioRepository repositorio)
        {
            _funcionarioRepository = repositorio;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_funcionarioRepository.GetAll());
        }

        [HttpPost]
        [Route("AddFuncionario")]
        public IActionResult AddFuncionario(FuncionarioViewModel funcionario)
        {
            try
            {
                _funcionarioRepository.Add(
                    new Funcionario
                    {
                        cargo = funcionario.cargo,
                        cidade = funcionario.cidade,
                        DataNascimento = funcionario.DataNascimento,
                        endereco = funcionario.endereco,
                        nome = funcionario.nome,
                        salario = funcionario.salario,
                        UF = funcionario.UF
                    });
                
                return Ok("Cadastrado com Sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest("Não Cadastrado. Erro: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("/GetFuncionarioById/{id}")]
        public async Task<Funcionario> GetPorId(int id)
        {
            return await _funcionarioRepository.GetById(id);
        }

        [HttpDelete]
        [Route("{idCategoria}/RemoveFuncionario")]
        public async Task<IActionResult> RemoveCategoria(int idCategoria)
        {
            try
            {
                var categoriaEncontrada = await _funcionarioRepository.GetById(idCategoria);
                if (categoriaEncontrada is not null)
                {
                    _funcionarioRepository.Delete(categoriaEncontrada);

                    return Ok("Funcionário Removida com sucesso");
                }
                return BadRequest("Funcionário não existe");

            }
            catch (Exception ex)
            {

                return BadRequest("Erro ao remover Funcionário: " + ex);
            }
        }

        [HttpPut]
        [Route("Updatefuncionario")]
        public IActionResult UpdateCategoria(Funcionario funcionario)
        {
            try
            {
                _funcionarioRepository.Update(funcionario);

                return Ok("Atualizado com Sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest("Não atualizado. Erro: " + ex.Message);
            }
        }
    }
}
