using loja_BD.DAL;
using loja_BD.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace loja_BD.Views
{
    public class Metodos3Ptech : DataAccessLayer
    {
        public List<Produto> ConsultarListaProdutos()
        {
            DataTable dataTable = new DataTable();

            List<Produto> listaProdutos = new List<Produto>();
            Produto produto = new Produto();

            try
            {
                pgsqlConnection = new NpgsqlConnection(connString1);
                pgsqlConnection.Open();

                string cmdSelect = "SELECT idproduto, nome, valor, categoria " +
                                "FROM loja.tbproduto";

                NpgsqlCommand npgsqlCommand = new NpgsqlCommand(cmdSelect, pgsqlConnection);

                NpgsqlDataReader dataReader = npgsqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    produto = new Produto();

                    produto.idProduto = String.Format("{0}", dataReader["idproduto"]);
                    produto.nome = String.Format("{0}", dataReader["nome"]);
                    produto.valor = String.Format("{0}", dataReader["valor"]);
                    produto.categoria = String.Format("{0}", dataReader["categoria"]);

                    listaProdutos.Add(produto);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar os Produtos: " + ex.Message);
            }
            finally
            {
                pgsqlConnection.Close();
            }
            return listaProdutos;
        }

        public List<Funcionario> ConsultarListaFuncionarios()
        {
            List<Funcionario> listaFuncionarios = new List<Funcionario>();
            Funcionario funcionario = new Funcionario();
            Pessoa pessoa = new Pessoa();
            Endereco endereco = new Endereco();

            try
            {
                pgsqlConnection = new NpgsqlConnection(connString1);
                pgsqlConnection.Open();
                string cmdSelect = "SELECT idvendedor, cpf, cargo, salario " +
                                "FROM loja.tbfuncionario";

                NpgsqlCommand npgsqlCommand = new NpgsqlCommand(cmdSelect, pgsqlConnection);

                NpgsqlDataReader dataReader = npgsqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    funcionario = new Funcionario();

                    funcionario.id = Convert.ToInt32(dataReader["idvendedor"]);
                    funcionario.cargo = String.Format("{0}", dataReader["cargo"]);
                    funcionario.salario = String.Format("R$ {0}", dataReader["salario"]);

                    listaFuncionarios.Add(funcionario);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar os Produtos: " + ex.Message);
            }
            finally
            {
                pgsqlConnection.Close();
            }
            return listaFuncionarios;
        }
    
        public Funcionario ConsultarFuncionario(string cpf)
        {
            Funcionario funcionario = new Funcionario();

            try
            {
                pgsqlConnection = new NpgsqlConnection(connString1);
                pgsqlConnection.Open();
                string cmdSelect = "SELECT f.idvendedor, f.cpf, f.cargo, f.salario, " +
                                "p.cpf, p.nome, p.datanascimento, p.ddd, p.telefone, p.email, p.endereco, " +
                                "e.idendereco, e.rua, e.numero, e.bairro, e.complemento, e.cep, e.cidade, e.estado " +
                                "FROM loja.tbfuncionario AS f, loja.tbpessoa AS p, loja.tbendereco AS e " +
                                "WHERE f.cpf LIKE @cpf " +
                                "AND p.cpf LIKE f.cpf " +
                                "AND e.idendereco = p.endereco";
                
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand(cmdSelect, pgsqlConnection);
                npgsqlCommand.Parameters.AddWithValue("cpf", cpf);

                NpgsqlDataReader dataReader = npgsqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    funcionario = new Funcionario();

                    funcionario.id = Convert.ToInt32(dataReader["idvendedor"]);
                    funcionario.cargo = String.Format("{0}", dataReader["cargo"]);
                    funcionario.salario = String.Format("{0}", dataReader["salario"]);

                    funcionario.pessoa.cpf = String.Format("{0}", dataReader["cpf"]);
                    funcionario.pessoa.nome = String.Format("{0}", dataReader["nome"]);
                    funcionario.pessoa.dataNascimento = String.Format("{0}", dataReader["datanascimento"]);
                    funcionario.pessoa.telefone = String.Format("({0}) {1}", dataReader["ddd"], dataReader["telefone"]);
                    funcionario.pessoa.email = String.Format("{0}", dataReader["email"]);

                    funcionario.pessoa.endereco.rua = String.Format("{0}", dataReader["rua"]);
                    funcionario.pessoa.endereco.numero = String.Format("{0}", dataReader["numero"]);
                    funcionario.pessoa.endereco.bairro = String.Format("{0}", dataReader["bairro"]);
                    funcionario.pessoa.endereco.complemento = String.Format("{0}", dataReader["complemento"]);
                    funcionario.pessoa.endereco.cep = Convert.ToDecimal(dataReader["cep"]);
                    funcionario.pessoa.endereco.cidade = String.Format("{0}", dataReader["cidade"]);
                    funcionario.pessoa.endereco.estado = String.Format("{0}", dataReader["estado"]);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao buscar Funcionario: " + ex.Message);
            }
            finally
            {
                pgsqlConnection.Close();
            }

            return funcionario;
        }
    }
}
