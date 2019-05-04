
namespace ApiCompras.Models
{
    public class Produto
    {
        public int produtoId { get; set; }
        public TipoProduto tipoProduto { get; set; }
        public string descricao { get; set; }
        public float preco { get; set; }
    }
}