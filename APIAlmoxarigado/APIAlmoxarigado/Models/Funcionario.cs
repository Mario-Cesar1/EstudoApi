using System.ComponentModel.DataAnnotations;

namespace APIAlmoxarigado.Models
{
    public class Funcionario
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string cargo { get; set; }
        public string DataNascimento { get; set; }
        public double salario { get; set; }
        public string endereco { get; set; }
        public string cidade { get; set; }
        public string UF { get; set; }
    }
}
