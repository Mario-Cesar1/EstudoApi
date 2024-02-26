using System.ComponentModel.DataAnnotations;

namespace APIAlmoxarigado.Models
{
    public class Categoria
    {
        [Key]
        public int id { get; set; }
        public string descricao { get; set; }
    }
}
