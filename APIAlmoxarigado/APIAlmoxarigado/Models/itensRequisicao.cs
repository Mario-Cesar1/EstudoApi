using System.ComponentModel.DataAnnotations;

namespace APIAlmoxarigado.Models
{
    public class itensRequisicao
    {
        [Key]
        public int IteID { get; set; }
        public Requisicao Requisicao { get; set; }

        public int CodigoRequisicao { get; set; }
        public Produto Produto { get; set; }

        public int CodigoProduto { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
    }
}
