using backEnd_bd.Application;
using backEnd_bd.Data.ModelsViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiRest_bd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngressosController : ControllerBase
    {
        private readonly Metodos _metodos;
        public IngressosController()
        {
            _metodos = new Metodos();
        }

        [HttpGet]
        [Route("listarIngressos")]
        public List<IngressoDTOList> ListarIngressos()
        {
            return _metodos.ListarIngressos();
        }

        [HttpGet]
        [Route("consultarIngresso/{codigo}")]
        public Object ConsultarIngresso(int codigo)
        {
            return _metodos.ConsultarIngresso(codigo);
        }
    }
}
