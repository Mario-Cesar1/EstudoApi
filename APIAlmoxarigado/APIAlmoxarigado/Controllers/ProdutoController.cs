using APIAlmoxarigado.Models;
using APIAlmoxarigado.Repository;
using APIAlmoxarigado.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace APIAlmoxarigado.Controllers
{
    [ApiController]
    [Route("api/v1/produto")]
    public class ProdutoController : ControllerBase
    {

        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository repositorio)
        {
            _produtoRepository = repositorio;
        }

        [HttpGet]
        [Route("Hello")]
        public IActionResult Hello()
        {
            return Ok("Hello Mundo");
        }

        [HttpGet]
        [Route("GetAllFake")]
        public IActionResult GetAllFake()
        {
            var produtos = new List<Produto>() {
                new Produto()
                {
                    id= 1,
                    nome = "PC HP",
                    estoque = 10
                },
                new Produto()
                {
                    id= 2,
                    nome = "PC DELL",
                    estoque = 20
                },
            };
            return Ok(produtos)  ;
        }

        [HttpGet]   
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_produtoRepository.GetAll());
        }

        [HttpPost]
        [Route("AddProdutosemFoto")]
        public IActionResult AdicionarProdutoSemFoto([FromForm]ProdutoViewModelSemFoto produto)
        {
            try
            {
                            _produtoRepository.Add(
                new Produto() { nome=produto.nome, estoque= produto.estoque, photourl=null, codigoCategoria = Convert.ToInt32(produto.codigoCategoria) }
                );

                return Ok("Cadastrado com Sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest("Não Cadastrado. Erro: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("AddProdutocomFoto")]
        public IActionResult AdicionarProdutoComFoto([FromForm] ProdutoViewModelComFoto produto)
        {
            try
            {
                var caminho = Path.Combine("Storage", produto.photo.FileName);
                using Stream fileStream = new FileStream(caminho, FileMode.Create);
                produto.photo.CopyTo(fileStream);

                _produtoRepository.Add(
                new Produto() { nome = produto.nome, estoque = produto.estoque, photourl = caminho, codigoCategoria = Convert.ToInt32(produto.codigoCategoria) }
    );

                return Ok("Cadastrado com Sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest("Não Cadastrado. Erro: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}/GetProdutoByID")]
        public IActionResult GetProdutoByID(int id)
        {
            return Ok(_produtoRepository.GetAll().Find(x=>x.id==id));
        }

        [HttpGet]
        [Route("{id}/GetFoto")]
        public IActionResult GetFoto(int id)
        {
            try
            {
                var produto = _produtoRepository.GetAll().Find(x => x.id == id);
                if (produto.photourl is not null)
                {
                    var dataBytes = System.IO.File.ReadAllBytes(produto.photourl);
                    return File(dataBytes, "image/jpg");
                }
                return BadRequest("Produto não tem foto cadastrada");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao fazer download: " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("{idProduto}/RemoveProduto")]
        public IActionResult RemoveProduto(int idProduto)
        {
            try
            {
                var categoriaEncontrada = _produtoRepository.GetAll().Find(x => x.id == idProduto);
                if (categoriaEncontrada is not null)
                {
                    _produtoRepository.Delete(
                        new Produto() { id = idProduto }
                        );

                    return Ok("Produto Removido com sucesso");
                }
                return BadRequest("Produto não existe");

            }
            catch (Exception ex)
            {

                return BadRequest("Erro ao remover produto: " + ex);
            }
        }
    }
}

