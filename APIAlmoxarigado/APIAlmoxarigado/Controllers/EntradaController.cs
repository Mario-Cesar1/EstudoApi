using APIAlmoxarigado.Infraestrutura;
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
        ProdutoRepository _produto = new ProdutoRepository();

        public IProdutoRepository _produtorepository;

        public EntradaController(IProdutoRepository repositorio)
        {
            _produtorepository = repositorio;
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
                    ProdutoController produto = new ProdutoController(_produto);
                    var ProdutoEntradaEncontrado = await _produtorepository.GetById(item.codigoProdutoEntrada);
                    ProdutoEntradaEncontrado.estoque = ProdutoEntradaEncontrado.estoque + item.quantidadeEntrada;
                    produto.UpdateProdutoEntrada(ProdutoEntradaEncontrado);
                }

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
