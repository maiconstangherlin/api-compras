namespace ApiCompras.Models
{
    public class CompraItem
    {
        public int CompraItemId { get; set; }
        public Compra Compra { get; set; }    
        public Produto Produto { get; set; }  
        public int Quantidade { get; set; }    
    }
}