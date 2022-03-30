using System.Collections.Generic;

namespace backEnd_bd.Data.ModelsViews
{
    public class IngressoModel
    {
        public string titulo { get; set; } = "";
        public double valor { get; set; } = 0;
        public string descricao { get; set; } = "";
    }

    public class ListaIngressos
    {
        public int codigoErro { get; set; } = 0;
        public string descricaoErro { get; set; } = "";
        public List<IngressoDTOList> listaIngressos { get; set; } = new List<IngressoDTOList>();
    }


    public class IngressoDTO
    {
        public int ID { get; set; } = 0;
        public int codigo { get; set; } = 0;
        public string titulo { get; set; } = "";
        public double valor { get; set; } = 0;
        public string descricao { get; set; } = "";
        public string poltrona { get; set; } = "";
    }
    public class IngressoDTOList
    {
        public int ID { get; set; } = 0;
        public int codigo { get; set; } = 0;
        public double valor { get; set; } = 0;
    }
}
