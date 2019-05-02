using System;

namespace ApiCompras.Models
{
    public class Compra
    {
        public int CompraId { get; set; }
        public DateTime dataHora { get; set; }
        public string atendente { get; set; }
        public string tipoPagamento { get; set; }
    }
}