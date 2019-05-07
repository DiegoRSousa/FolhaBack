using System.ComponentModel.DataAnnotations;

namespace FolhaBack.Models
{
    public class Trabalhador
    {
        public long Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public double Salario { get; set; }
    }
}