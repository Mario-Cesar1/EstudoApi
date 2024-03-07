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

        [HttpPost]
        [Route("AdicionarMotivo")]
        public IActionResult AdicionarMotivo(MotivoSaidaViewModel pMotivo)
        {
            try
            {
                var novoMotivo = new MotivoSaida()
                {
                    MOTDESCRICAO = pMotivo.MOTDESCRICAO,
                    CAMID = 1
                };
                _motivoSaidaRepository.Add(novoMotivo);
                return Ok("Cadastrado com sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest("Erro ao cadastrar: " + ex.Message);
            }
        }
    }
}
