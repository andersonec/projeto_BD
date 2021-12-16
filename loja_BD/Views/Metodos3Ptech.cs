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

                //using(NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSelect, pgsqlConnection))
                //{
                //    Adpt.Fill(dataTable);
                //}

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

                //cmd.Parameters.AddWithValue("varSql", "varIn");
                //cmd.ExecuteReader();

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
    }
}
