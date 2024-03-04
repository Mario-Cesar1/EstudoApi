using System.ComponentModel.DataAnnotations;

namespace APIAlmoxarigado.Models
{
    public class Requisicao
    {
        [Key]
        public int REQID { get; set; }
        public string REQDATA { get; set; }
        public string? REQOBSERVACAO { get; set; }
    }
}
