namespace loja_BD.Models
{
    public class Cliente
    {
        public int idCliente { get; set; }
        public Pessoa pessoa { get; set; } = new Pessoa();
    }
}
