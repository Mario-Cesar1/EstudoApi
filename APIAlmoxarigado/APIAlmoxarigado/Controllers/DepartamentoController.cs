using APIAlmoxarigado.Models;
using APIAlmoxarigado.Repository;
using APIAlmoxarigado.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace APIAlmoxarigado.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoController(IDepartamentoRepository repositorio)
        {
            _departamentoRepository = repositorio;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_departamentoRepository.GetAll());
        }

        [HttpGet]
        [Route("GetAllFake")]
        public IActionResult GetAllFake()
        {
            var departamentos = new List<Departamento>() {
                new Departamento()
                {
                    id= 1,
                    descricao = "Segurança",
                    situacao = false
                },
                new Departamento()
                {
                    id= 2,
                    descricao = "Financeiro",
                    situacao= true
                },
            };
            return Ok(departamentos);
        }


        [HttpPost]
        [Route("AddDepartamento")]
        public IActionResult AddDepartamento([FromForm] DepartamentoViewModel departamento)
        {
            try
            {
                _departamentoRepository.Add(
                    new Departamento() { descricao = departamento.descricao, situacao = departamento.situacao }
                );

                return Ok("Cadastrado com Sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest("Não Cadastrado. Erro: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("/GetDepartamentoById/{id}")]
        public async Task<Departamento> GetPorId(int id)
        {
            return await _departamentoRepository.GetById(id);
        }

        [HttpDelete]
        [Route("{idDepartamento}/RemoveDepartamento")]
        public async Task<IActionResult> RemoveDepartamento(int idDepartamento)
        {
            try
            {
                var departamentoEncontrodo = await _departamentoRepository.GetById(idDepartamento);
                if (departamentoEncontrodo is not null)
                {
                    _departamentoRepository.Delete(departamentoEncontrodo);

                    return Ok("Departamendo Removido com sucesso");
                }
                return BadRequest("Departamendo não existe");

            }
            catch (Exception ex)
            {

                return BadRequest("Erro ao remover departamendo: " + ex);
            }
        }

        [HttpPut]
        [Route("UpdateDepartamento")]
        public IActionResult UpdateCategoria(Departamento departamento)
        {
            try
            {
                _departamentoRepository.Update(departamento);

                return Ok("Atualizado com Sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest("Não atualizado. Erro: " + ex.Message);
            }
        }
    }
}

