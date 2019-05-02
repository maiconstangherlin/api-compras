
namespace ApiCompras.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public string Descricao { get; set; }
        public float Preco { get; set; }
    }
}