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
        public List<Produto> ConsultarListaProdutos()
        {
            Metodos3Ptech metodos3Ptech = new Metodos3Ptech();

            return metodos3Ptech.ConsultarListaProdutos();
        }

        [HttpGet("consultarListaFuncionarios")]
        public List<FuncionarioDTO> ConsultarListaFuncionarios()
        {
            Metodos3Ptech metodos3Ptech = new Metodos3Ptech();

            return metodos3Ptech.ConsultarListaFuncionarios();
        }

        [HttpGet("consultarFuncionario/{cpf}")]
        public Funcionario ConsultarFuncionario(string cpf)
        {
            Metodos3Ptech metodos3Ptech = new Metodos3Ptech();

            return metodos3Ptech.ConsultarFuncionario(cpf);
        }

        [HttpGet("consultarListaClientes")]
        public List<ClienteDTO> ConsultarListaClientes()
        {
            Metodos3Ptech metodos3Ptech = new Metodos3Ptech();

            return metodos3Ptech.ConsultarListaClientes();
        }

        [HttpGet("consultarCliente/{cpf}")]
        public Cliente ConsultarCliente(string cpf)
        {
            Metodos3Ptech metodos3Ptech = new Metodos3Ptech();

            return metodos3Ptech.ConsultarCliente(cpf);
        }

        [HttpGet("consultarListaCategorias")]
        public List<Categoria> ConsultarListaCategorias()
        {
            Metodos3Ptech metodos3Ptech = new Metodos3Ptech();

            return metodos3Ptech.ConsultarCategorias();
        }

        [HttpPost("inserirProdutoEstoque")]
        public RetornoConfirmacao InserirProdutoEstoque(Produto produto)
        {
            Metodos3Ptech metodos3Ptech = new Metodos3Ptech();

            return metodos3Ptech.InserirProdutoEstoque(produto);
        }
    }
}
