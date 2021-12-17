using System;
using System.Collections.Generic;

namespace loja_BD.Models.body
{
    public class Venda
    {
        public List<Produto> listaProdutos { get; set; } = new List<Produto>();
        public DateTime data { get; set; } = new DateTime();
        public int idVendedor { get; set; }
        public decimal comissao { get; set; }
    }
}
