using System.ComponentModel.DataAnnotations;

namespace APIAlmoxarigado.Models
{
    public class Entrada
    {
        [Key]
        public int id { get; set; }
        public DateTime dataEntrada { get; set; }
        public List<itensEntrada> itensEntrada { get; set; }
    }
}
