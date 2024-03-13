using System.ComponentModel.DataAnnotations;

namespace APIAlmoxarigado.Models
{
    public class itensEntrada
    {
        [Key]
        public int id { get; set; }
        public Entrada Entrada { get; set; }
        public int codigoEntrada { get; set; }
        public int codigoProdutoEntrada { get; set; }
        public Produto Produto { get; set; }
        public int quantidadeEntrada { get; set; }
    }
}
