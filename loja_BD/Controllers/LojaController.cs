using loja_BD.Models;
using loja_BD.Views;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace loja_BD.Controllers
{
    [Route("api/[controller]")]
    public class LojaController : Controller
    {
        [HttpGet("consultarListaProdutos")]
        public List<Produto> ConsultarListaFuncionarios()
        {
            Metodos3Ptech metodos3Ptech = new Metodos3Ptech();

            return metodos3Ptech.ConsultarListaProdutos();
        }

    }
}
