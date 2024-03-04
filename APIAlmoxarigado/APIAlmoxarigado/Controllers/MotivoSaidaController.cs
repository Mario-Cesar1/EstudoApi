using APIAlmoxarigado.Models;
using APIAlmoxarigado.Repository;
using APIAlmoxarigado.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace APIAlmoxarigado.Controllers
{
    [ApiController]
    [Route("api/v1/motivoSaida")]
    public class MotivoSaidaController : Controller
    {
        private readonly IMotivoSaidaRepository _motivoSaidaRepository;

        public MotivoSaidaController(IMotivoSaidaRepository repositorio)
        {
            _motivoSaidaRepository = repositorio;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_motivoSaidaRepository.GetAll());
        }

        [HttpPost]
        [Route("AddMotivoSaida")]
        public IActionResult AddMotivoSaida(MotivoSaidaViewModel motivoSaida)
        {
            try
            {
                _motivoSaidaRepository.Add(
                    new MotivoSaida() { MOTDESCRICAO = motivoSaida.MOTDESCRICAO, CAMID = motivoSaida.CAMID }
                );

                return Ok("Cadastrado com Sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest("Não Cadastrado. Erro: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("/GetSaidaMotivoById/{id}")]
        public async Task<MotivoSaida> GetPorId(int id)
        {
            return await _motivoSaidaRepository.GetById(id);
        }

        [HttpDelete]
        [Route("{idMotivoSaida}/RemoveMotivoSaida")]
        public async Task<IActionResult> RemoveMotivoSaida(int idMotivoSaida)
        {
            try
            {
                var motivoSaidaEncontrada = await _motivoSaidaRepository.GetById(idMotivoSaida);
                if (motivoSaidaEncontrada is not null)
                {
                    _motivoSaidaRepository.Delete(motivoSaidaEncontrada);

                    return Ok("MotivoSaida Removida com sucesso");
                }
                return BadRequest("MotivoSaida não existe");

            }
            catch (Exception ex)
            {

                return BadRequest("Erro ao remover motivoSaida: " + ex);
            }
        }

        [HttpPut]
        [Route("UpdateMotivoSaida")]
        public IActionResult UpdateMotivoSaida(MotivoSaida motivoSaida)
        {
            try
            {
                _motivoSaidaRepository.Update(motivoSaida);

                return Ok("Atualizado com Sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest("Não atualizado. Erro: " + ex.Message);
            }
        }
    }
}
