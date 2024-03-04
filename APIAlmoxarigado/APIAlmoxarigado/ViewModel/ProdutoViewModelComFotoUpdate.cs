using System.ComponentModel.DataAnnotations;

namespace APIAlmoxarigado.ViewModel
{
    public class ProdutoViewModelComFotoUpdate
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public int estoque { get; set; }
        public int? codigoCategoria { get; set; }
        public IFormFile photo { get; set; }
    }
}
