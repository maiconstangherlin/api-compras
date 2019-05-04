using System;
using System.Collections.Generic;

namespace ApiCompras.Models
{
    public class Compra
    {
        public int compraId { get; set; }
        public DateTime dataHora { get; set; }
        public string atendente { get; set; }
        public string tipoPagamento { get; set; }
        public List<CompraItem> compraItens { get; set; }
    }
}