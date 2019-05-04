namespace ApiCompras.Models
{
    public class CompraItem
    {
        public int compraItemId { get; set; }        
        public Produto produto { get; set; }  
        public int quantidade { get; set; }    
    }
}