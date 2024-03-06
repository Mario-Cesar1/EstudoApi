using System.ComponentModel.DataAnnotations;

namespace APIAlmoxarigado.Models
{
    public class Requisicao
    {
        [Key]
        public int Codigo { get; set; }

        public DateTime DataRequisicao { get; set; }

        public List<itensRequisicao> itens { get; set; }
    }
}
