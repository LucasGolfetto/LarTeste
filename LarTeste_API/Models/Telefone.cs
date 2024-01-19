using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LarTeste_API.Models
{
    public class Telefone
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string Numero { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public bool IsWhatsApp { get; set; }
        [Required]
        public int PessoaId { get; set; }
    }
}
