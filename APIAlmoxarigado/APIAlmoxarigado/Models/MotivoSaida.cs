using System.ComponentModel.DataAnnotations;

namespace APIAlmoxarigado.Models
{
    public class MotivoSaida
    {
        [Key]
        public int MOTID { get; set; }
        public string MOTDESCRICAO { get; set; }
        public int CAMID { get; set; }

        public CategoriaMotivo CategoriaMotivo { get; set; }
    }
}
