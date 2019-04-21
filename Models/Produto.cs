using System.ComponentModel.DataAnnotations;

namespace ApiCompras.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}