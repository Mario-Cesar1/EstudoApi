using APIAlmoxarigado.Models;

namespace APIAlmoxarigado.ViewModel
{
    public class ProdutoViewModelComFoto
    {
        public string nome { get; set; }
        public int estoque { get; set; }
        public int? codigoCategoria { get; set; }
        public IFormFile photo { get; set; }
    }
}
