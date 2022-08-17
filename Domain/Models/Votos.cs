using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Votos
    {
        [Key]
        public int IdVoto { get; set; }        
        public int idUsuario { get; set; }
        public int idRestaurante { get; set; }
        public string horaVoto { get; set; } 
        [NotMapped]
        public Restaurante restaurantes { get; set; }
        [NotMapped]
        public Usuario usuarios { get; set; }
    }
}
