using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace loja_BD.Models
{
    public class Produto
    {
        public int idProduto { get; set; }
        public string nome { get; set; }
        public string valor { get; set; }
        public string categoria { get; set; }
        public int quantidade { get; set; }
    }
}
