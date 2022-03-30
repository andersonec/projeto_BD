using backEnd_bd.Application;
using backEnd_bd.Data.ModelsViews;
using frontEnd_mvc_bd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace frontEnd_mvc_bd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly Metodos _metodos;

        public HomeController(ILogger<HomeController> logger)
        {
            _metodos = new Metodos();
            _logger = logger;
        }

        [HttpGet]
        public IActionResult TicketsList()
        {
            List<IngressoDTOList> listaIngressos = new List<IngressoDTOList>();

            listaIngressos = _metodos.ListarIngressos();

            ViewBag.IngressoDTOList = listaIngressos;

            return View(listaIngressos);
        }

        [HttpGet]
        public IActionResult TicketsDetails(int codigo)
        {
            IngressoDTO ingresso = new IngressoDTO();

            ingresso = _metodos.ConsultarIngresso(codigo);

            ViewBag.IngressoDTO = ingresso;
            
            return View(ingresso);
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
