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
        #region MÉTODOS PARA CONSULTAS
        public List<FuncionarioDTO> ConsultarListaFuncionarios()
        {
            List<FuncionarioDTO> listaFuncionarios = new List<FuncionarioDTO>();
            FuncionarioDTO funcionario = new FuncionarioDTO();

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
                    funcionario = new FuncionarioDTO();

                    funcionario.idFuncionario = Convert.ToInt32(dataReader["idvendedor"]);
                    funcionario.cargo = String.Format("{0}", dataReader["cargo"]);
                    funcionario.cpf = String.Format(@"{0:000\.000\.000\-00}", dataReader["cpf"]);
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
                    funcionario.pessoa.endereco.cep = String.Format(@"{0:00\.000\-000}", dataReader["cep"]);
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


        public List<ClienteDTO> ConsultarListaClientes()
        {
            List<ClienteDTO> listaClientes = new List<ClienteDTO>();
            ClienteDTO cliente = new ClienteDTO();

            try
            {
                pgsqlConnection = new NpgsqlConnection(connString1);
                pgsqlConnection.Open();
                string cmdSelect = "SELECT c.idcliente, c.cpf, p.nome, p.cpf  " +
                                "FROM loja.tbcliente AS c, loja.tbpessoa AS p " +
                                "WHERE c.cpf LIKE p.cpf";

                NpgsqlCommand npgsqlCommand = new NpgsqlCommand(cmdSelect, pgsqlConnection);

                NpgsqlDataReader dataReader = npgsqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    cliente = new ClienteDTO();

                    cliente.idCliente = Convert.ToInt32(dataReader["idcliente"]);
                    cliente.nome = String.Format("{0}", dataReader["nome"]);
                    cliente.cpf = String.Format(@"{0:000\.000\.000\-00}", dataReader["cpf"]);

                    listaClientes.Add(cliente);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar os Clientes: " + ex.Message);
            }
            finally
            {
                pgsqlConnection.Close();
            }
            return listaClientes;
        }

        public Cliente ConsultarCliente(string cpf)
        {
            Cliente cliente = new Cliente();

            try
            {
                pgsqlConnection = new NpgsqlConnection(connString1);
                pgsqlConnection.Open();
                string cmdSelect = "SELECT c.idcliente, c.cpf, " +
                                "p.cpf, p.nome, p.datanascimento, p.ddd, p.telefone, p.email, p.endereco, " +
                                "e.idendereco, e.rua, e.numero, e.bairro, e.complemento, e.cep, e.cidade, e.estado " +
                                "FROM loja.tbcliente AS c, loja.tbpessoa AS p, loja.tbendereco AS e " +
                                "WHERE f.cpf LIKE @cpf " +
                                "AND p.cpf LIKE f.cpf " +
                                "AND e.idendereco = p.endereco";

                NpgsqlCommand npgsqlCommand = new NpgsqlCommand(cmdSelect, pgsqlConnection);
                npgsqlCommand.Parameters.AddWithValue("cpf", cpf);

                NpgsqlDataReader dataReader = npgsqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    cliente = new Cliente();

                    cliente.idCliente = Convert.ToInt32(dataReader["idvendedor"]);

                    cliente.pessoa.cpf = String.Format("{0}", dataReader["cpf"]);
                    cliente.pessoa.nome = String.Format("{0}", dataReader["nome"]);
                    cliente.pessoa.dataNascimento = String.Format("{0}", dataReader["datanascimento"]);
                    cliente.pessoa.telefone = String.Format("({0}) {1}", dataReader["ddd"], dataReader["telefone"]);
                    cliente.pessoa.email = String.Format("{0}", dataReader["email"]);

                    cliente.pessoa.endereco.rua = String.Format("{0}", dataReader["rua"]);
                    cliente.pessoa.endereco.numero = String.Format("{0}", dataReader["numero"]);
                    cliente.pessoa.endereco.bairro = String.Format("{0}", dataReader["bairro"]);
                    cliente.pessoa.endereco.complemento = String.Format("{0}", dataReader["complemento"]);
                    cliente.pessoa.endereco.cep = String.Format(@"{0:00\.000\-000}", dataReader["cep"]);
                    cliente.pessoa.endereco.cidade = String.Format("{0}", dataReader["cidade"]);
                    cliente.pessoa.endereco.estado = String.Format("{0}", dataReader["estado"]);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao buscar Cliente: " + ex.Message);
            }
            finally
            {
                pgsqlConnection.Close();
            }

            return cliente;
        }


        public List<Produto> ConsultarListaProdutos()
        {
            List<Produto> listaProdutos = new List<Produto>();
            Produto produto = new Produto();

            try
            {
                pgsqlConnection = new NpgsqlConnection(connString1);
                pgsqlConnection.Open();

                string cmdSelect = "SELECT p.idproduto, p.nome, p.valor, p.categoria, q.quantidade " +
                                "FROM loja.tbproduto AS p, loja.tbestoque AS q " +
                                "WHERE q.idproduto = p.idproduto";

                NpgsqlCommand npgsqlCommand = new NpgsqlCommand(cmdSelect, pgsqlConnection);

                NpgsqlDataReader dataReader = npgsqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    produto = new Produto();

                    produto.idProduto = Convert.ToInt32(dataReader["idproduto"]);
                    produto.nome = String.Format("{0}", dataReader["nome"]);
                    produto.valor = String.Format("{0}", dataReader["valor"]);
                    produto.categoria = String.Format("{0}", dataReader["categoria"]);
                    produto.quantidade = Convert.ToInt32(dataReader["quantidade"]);

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

        public List<Categoria> ConsultarCategorias()
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            Categoria categoria = new Categoria();

            try
            {
                pgsqlConnection = new NpgsqlConnection(connString1);
                pgsqlConnection.Open();

                string cmdSelect = "SELECT categoria, descricao " +
                                "FROM loja.tbcategoria";

                NpgsqlCommand npgsqlCommand = new NpgsqlCommand(cmdSelect, pgsqlConnection);

                NpgsqlDataReader dataReader = npgsqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    categoria = new Categoria();

                    categoria.categoria = String.Format("{0}", dataReader["categoria"]);
                    categoria.descricao = String.Format("{0}", dataReader["descricao"]);

                    listaCategorias.Add(categoria);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar as Categorias: " + ex.Message);
            }
            finally
            {
                pgsqlConnection.Close();
            }


            return listaCategorias;
        }

        #endregion



        public RetornoConfirmacao InserirProdutoEstoque(Produto produto)
        {
            RetornoConfirmacao retornoConfirmacao = new RetornoConfirmacao();
            int idprodutoIn = 0;
            try
            {
                pgsqlConnection = new NpgsqlConnection(connString1);
                pgsqlConnection.Open();
                string cmdInsert = "WITH ins AS (" +
                                "INSERT INTO loja.tbproduto(nome, valor, categoria) " +
                                "VALUES (@nome, @valor, @categoria) " +
                                "RETURNING idproduto) " +
                                "INSERT INTO loja.tbestoque(idproduto, quantidade) " +
                                "SELECT idproduto, @quantidade " +
                                "FROM ins";
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand(cmdInsert, pgsqlConnection);
                npgsqlCommand.Parameters.AddWithValue("nome", produto.nome);
                npgsqlCommand.Parameters.AddWithValue("valor", Convert.ToDecimal(produto.valor));
                npgsqlCommand.Parameters.AddWithValue("categoria", produto.categoria);
                npgsqlCommand.Parameters.AddWithValue("quantidade", produto.quantidade);
                npgsqlCommand.ExecuteNonQuery();


                //string cmdInsert = "INSERT INTO loja.tbproduto(nome, valor, categoria) " +
                //                "VALUES (@nome, @valor, @categoria) " +
                //                "RETURNING idproduto";
                //NpgsqlCommand npgsqlCommand = new NpgsqlCommand(cmdInsert, pgsqlConnection);
                //npgsqlCommand.Parameters.AddWithValue("nome", produto.nome);
                //npgsqlCommand.Parameters.AddWithValue("valor", Convert.ToDecimal(produto.valor));
                //npgsqlCommand.Parameters.AddWithValue("categoria", produto.categoria);
                //npgsqlCommand.ExecuteReader();

                //NpgsqlDataReader dataReader = npgsqlCommand.ExecuteReader();
                //dataReader.Read();
                //idprodutoIn = Convert.ToInt32(dataReader["idproduto"]);
                //pgsqlConnection.Close();

                //pgsqlConnection = new NpgsqlConnection(connString1);
                //pgsqlConnection.Open();
                //string cmdInsert2 = "INSERT INTO loja.tbestoque(idproduto, quantidade) " +
                //                "VALUES (@idproduto, @quantidade)";
                //NpgsqlCommand npgsqlCommand2 = new NpgsqlCommand(cmdInsert2, pgsqlConnection);
                //npgsqlCommand.Parameters.AddWithValue("quantidade", produto.quantidade);
                //npgsqlCommand.Parameters.AddWithValue("idproduto", idprodutoIn);
                //npgsqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                retornoConfirmacao.codigoErro = 1;
                retornoConfirmacao.mensagemErro = "ERRO AO CADASTRAR PRODUTO";
                retornoConfirmacao.status = "";

                throw new Exception("Erro ao inserir Produto: " + ex.Message);
            }
            finally
            {
                retornoConfirmacao.codigoErro = 0;
                retornoConfirmacao.mensagemErro = "";
                retornoConfirmacao.status = "PRODUTO INSERIDO NO ESTOQUE.";

                pgsqlConnection.Close();
            }

            return retornoConfirmacao;
        }



        public RetornoConfirmacao RealizarVenda()
        {
            RetornoConfirmacao retornoConfirmacao = new RetornoConfirmacao();

            /*
             * NO ATO DA VENDA, INSERIR EM LOJA.TBVENDA (PRODUTOS, DATA, IDVENDEDOR E COMISSAO)
             * REALIZAR A SOMA DOS VALORES DE TODOS OS PRODUTOS
             * RETIRAR PRODUTOS DE TB.ESTOQUE
             */

             
            return retornoConfirmacao;
        }





    }
}
