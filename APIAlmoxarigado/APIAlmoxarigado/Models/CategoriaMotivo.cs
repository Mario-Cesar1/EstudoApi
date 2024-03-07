using System.ComponentModel.DataAnnotations;

namespace APIAlmoxarigado.Models
{
    public class CategoriaMotivo
    {
        [Key]
        public int CAMID { get; set; }
        public string CAMDESCRICAO { get; set; }

        public List<MotivoSaida> Motivos { get; set; }
    }
}
