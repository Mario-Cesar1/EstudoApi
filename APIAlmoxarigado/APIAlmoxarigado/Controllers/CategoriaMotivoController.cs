using APIAlmoxarigado.Models;
using APIAlmoxarigado.Repository;
using APIAlmoxarigado.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace APIAlmoxarigado.Controllers
{
    [ApiController]
    [Route("api/v1/categoriaMotivo")]
    public class CategoriaMotivoController : Controller
    {
        private readonly ICategoriaMotivoRepository _categoriaMotivoRepository;

        public CategoriaMotivoController(ICategoriaMotivoRepository repositorio)
        {
            _categoriaMotivoRepository = repositorio;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_categoriaMotivoRepository.GetAll());
        }

        [HttpPost]
        [Route("AddCategoriaMotivo")]
        public IActionResult AddCategoriaMotivo(CategoriaMotivoViewModel categoriaMotivo)
        {
            try
            {
                _categoriaMotivoRepository.Add(
                    new CategoriaMotivo() { CAMDESCRICAO = categoriaMotivo.CAMDESCRICAO }
                );

                return Ok("Cadastrado com Sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest("Não Cadastrado. Erro: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("/GetCategoriaMotivoById/{id}")]
        public async Task<CategoriaMotivo> GetPorId(int id)
        {
            return await _categoriaMotivoRepository.GetById(id);
        }

        [HttpDelete]
        [Route("{idCategoriaMotivo}/RemoveCategoriaMotivo")]
        public async Task<IActionResult> RemoveCategoriaMotivo(int idCategoriaMotivo)
        {
            try
            {
                var categoriaMotivoEncontrada = await _categoriaMotivoRepository.GetById(idCategoriaMotivo);
                if (categoriaMotivoEncontrada is not null)
                {
                    _categoriaMotivoRepository.Delete(categoriaMotivoEncontrada);

                    return Ok("CategoriaMotivo Removida com sucesso");
                }
                return BadRequest("CategoriaMotivo não existe");

            }
            catch (Exception ex)
            {

                return BadRequest("Erro ao remover categoriaMotivo: " + ex);
            }
        }

        [HttpPut]
        [Route("UpdateCategoriaMotivo")]
        public IActionResult UpdateCategoriaMotivo(CategoriaMotivo categoriaMotivo)
        {
            try
            {
                _categoriaMotivoRepository.Update(categoriaMotivo);

                return Ok("Atualizado com Sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest("Não atualizado. Erro: " + ex.Message);
            }
        }
    }

}
