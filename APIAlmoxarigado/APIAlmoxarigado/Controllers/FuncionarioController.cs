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
        public IActionResult AddCategoria(Funcionario funcionario)
        {
            try
            {
                _funcionarioRepository.Add(funcionario);
                
                return Ok("Cadastrado com Sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest("Não Cadastrado. Erro: " + ex.Message);
            }
        }
    }
}
