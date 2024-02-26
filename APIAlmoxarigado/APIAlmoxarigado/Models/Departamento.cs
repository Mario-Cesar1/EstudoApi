using System.ComponentModel.DataAnnotations;

namespace APIAlmoxarigado.Models
{
    public class Departamento
    {
        [Key]
        public int id { get; set; }
        public string descricao { get; set; }
        public bool situacao { get; set; }
    }
}
