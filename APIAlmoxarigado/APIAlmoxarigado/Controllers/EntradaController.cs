using APIAlmoxarigado.Models;
using APIAlmoxarigado.Repository;
using APIAlmoxarigado.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace APIAlmoxarigado.Controllers
{
    [ApiController]
    [Route("api/v1/entrada")]
    public class EntradaController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public EntradaController(IProdutoRepository repositorio)
        {
            _produtoRepository = repositorio;
        }

        EntradaRepository _repository = new EntradaRepository();

        [HttpPost]
        [Route("AdicionarEntrada")]
        public async Task<IActionResult> AdicionarEntrada(EntradaViewModel carrinho)
        {

            try
            {
                List<itensEntrada> lista = new List<itensEntrada>();
                foreach (var item in carrinho.itensEntrada)
                {
                    lista.Add(
                          new itensEntrada()
                          {
                              codigoProdutoEntrada = item.codigoProdutoEntrada,
                              quantidadeEntrada = item.quantidadeEntrada
                          }
                   );

                    int i = 0;
                    _repository.Add(lista);
                    var a = carrinho.itensEntrada;
                    var b = item.quantidadeEntrada;
                }


                ViewBag.produtoEncontrado = await _produtoRepository.GetById(item.codigoProdutoEntrada);

                _produtoRepository.Update(new Produto()
                {
                    id = ViewBag.produtoEncontrado.id,
                    nome = ViewBag.produtoEncontrado.nome,
                    estoque = ViewBag.produtoEncontrado.estoque + item.quantidadeEntrada,
                    photourl = ViewBag.produtoEncontrado.photourl,
                    codigoCategoria = ViewBag.produtoEncontrado.codigoCategoria,
                });

                Entrada entradaNova = new Entrada()
                {
                    dataEntrada = carrinho.dataEntrada,
                    itensEntrada = lista

                };

                _repository.Add(entradaNova);

                return Ok("Cadastrado com sucesso");

            }
            catch (Exception ex)
            {

                return Ok("Não cadastro" + ex.Message);
            }
        }
    }
}
