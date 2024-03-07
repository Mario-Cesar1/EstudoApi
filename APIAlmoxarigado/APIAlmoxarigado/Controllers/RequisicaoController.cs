using APIAlmoxarigado.Models;
using APIAlmoxarigado.Repository;
using APIAlmoxarigado.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace APIAlmoxarigado.Controllers
{
    [ApiController]
    [Route("api/v1/requisicao")]
    public class RequisicaoController : Controller
    {
        RequisicaoRepository _repository = new RequisicaoRepository();

        [HttpPost]
        [Route("AdicionarRequisicao")]
        public IActionResult AdicionarRequisicao(RequisicaoViewModel carrinho)
        {

            try
            {
                List<itensRequisicao> lista = new List<itensRequisicao>();
                foreach (var item in carrinho.itens)
                {

                    lista.Add(
                          new itensRequisicao()
                          {
                              CodigoProduto = item.CodigoProduto,
                              Preco = item.Preco,
                              Quantidade = item.Quantidade
                          }
                   );
                }

                Requisicao requisicaoNova = new Requisicao()
                {
                    DataRequisicao = carrinho.DataRequisicao,
                    itens = lista

                };

                _repository.Add(requisicaoNova);

                return Ok("Cadastrado com sucesso");

            }
            catch (Exception ex)
            {

                return Ok("Não cadastro" + ex.Message);
            }
        }
    }
}
