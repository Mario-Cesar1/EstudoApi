using APIAlmoxarigado.Models;
using APIAlmoxarigado.Repository;
using APIAlmoxarigado.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace APIAlmoxarigado.Controllers
{
    [ApiController]
    [Route("api/v1/categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository repositorio)
        {
            _categoriaRepository = repositorio;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_categoriaRepository.GetAll());
        }

        [HttpGet]
        [Route("GetAllFake")]
        public IActionResult GetAllFake()
        {
            var categorias = new List<Categoria>() {
                new Categoria()
                {
                    id= 1,
                    descricao = "Eletronicos"
                },
                new Categoria()
                {
                    id= 2,
                    descricao = "Comidas"
                },
            };
            return Ok(categorias);
        }

        [HttpPost]
        [Route("AddCategoria")]
        public IActionResult AddCategoria([FromForm] CategoriaViewModel categoria)
        {
            try
            {
                _categoriaRepository.Add(
                    new Categoria() { descricao=categoria.descricao }
                );

                return Ok("Cadastrado com Sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest("Não Cadastrado. Erro: " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("RemoveCategoria")]
        public IActionResult RemoveCategoria([FromForm] CategoriaDeleteViewModel idCategoria)
        {
            try
            {
                var categoriaEncontrada = _categoriaRepository.GetAll().Find(x => x.id == Convert.ToInt32(idCategoria));
                if (categoriaEncontrada is not null)
                {
                    _categoriaRepository.Delete(
                        new Categoria() { id = Convert.ToInt32(idCategoria)}
                        );

                    return Ok("Categoria Removida com sucesso");
                }
                return BadRequest("Categoria não existe");

            }
            catch (Exception ex)
            {

                return BadRequest("Erro ao remover categoria: " + ex);
            }
        }
    }
}
