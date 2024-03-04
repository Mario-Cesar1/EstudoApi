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
        private readonly IRequisicaoRepository _requisicaoRepository;

        public RequisicaoController(IRequisicaoRepository repositorio)
        {
            _requisicaoRepository = repositorio;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_requisicaoRepository.GetAll());
        }

        [HttpPost]
        [Route("AddRequisicao")]
        public IActionResult AddRequisicao(RequisicaoViewModel requisicao)
        {
            try
            {
                _requisicaoRepository.Add(
                    new Requisicao() { REQDATA = requisicao.REQDATA, REQOBSERVACAO = requisicao.REQOBSERVACAO }
                );

                return Ok("Cadastrado com Sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest("Não Cadastrado. Erro: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("/GetRequisicaoById/{id}")]
        public async Task<Requisicao> GetPorId(int id)
        {
            return await _requisicaoRepository.GetById(id);
        }

        [HttpDelete]
        [Route("{idRequisicao}/RemoveRequisicao")]
        public async Task<IActionResult> RemoveRequisicao(int idRequisicao)
        {
            try
            {
                var RequisicaoEncontrada = await _requisicaoRepository.GetById(idRequisicao);
                if (RequisicaoEncontrada is not null)
                {
                    _requisicaoRepository.Delete(RequisicaoEncontrada);

                    return Ok("Requisição Removida com sucesso");
                }
                return BadRequest("Requisição não existe");

            }
            catch (Exception ex)
            {

                return BadRequest("Erro ao remover Requisição: " + ex);
            }
        }

        [HttpPut]
        [Route("UpdateRequisicao")]
        public IActionResult UpdateRequisicao(Requisicao requisicao)
        {
            try
            {
                _requisicaoRepository.Update(requisicao);

                return Ok("Atualizado com Sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest("Não atualizado. Erro: " + ex.Message);
            }
        }
    }
}
