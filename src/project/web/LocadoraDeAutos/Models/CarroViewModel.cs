using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraDeAutos.Models
{
    public class CarroViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        [Range(minimum: 0.01, maximum: (double)decimal.MaxValue)]
        [Column(TypeName = "money")]
        public decimal Preco { get; set; }
    }
}