using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Restaurante
    {
        [Key]
        public int IdRestaurante { get; set; }
        public int codigoRestaurante { get; set; }
        public string nomeRestaurante { get; set; }        
    }
}
