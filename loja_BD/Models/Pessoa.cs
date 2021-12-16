using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace loja_BD.Models
{
    public class Pessoa
    {
        public string cpf { get; set; }
        public string nome { get; set; }
        public string dataNascimento { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public Endereco endereco { get; set; } = new Endereco();
    }
}
