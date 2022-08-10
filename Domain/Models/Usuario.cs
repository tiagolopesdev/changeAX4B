using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public int CodigoUsuario { get; set; }
        public string NomeUsuario { get; set; }
    }
}
