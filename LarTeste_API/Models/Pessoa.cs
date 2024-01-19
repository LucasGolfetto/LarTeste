using System.ComponentModel.DataAnnotations;

namespace LarTeste_API.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(14)]
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        [Required]
        public bool EstaAtivo { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
    }
}
