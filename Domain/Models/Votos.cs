using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Votos
    {
        [Key]
        public int Id { get; set; }        
        public int idUsuario { get; set; }
        public int idRestaurante { get; set; }
        public DateTime horaVoto { get; set; }        
    }
}
