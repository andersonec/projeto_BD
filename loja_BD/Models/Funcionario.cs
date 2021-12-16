using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace loja_BD.Models
{
    public class Funcionario
    {
        public int id { get; set; }
        public string cargo { get; set; }
        public string salario { get; set; }
        public Pessoa pessoa { get; set; } = new Pessoa();
    }
}
