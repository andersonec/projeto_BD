using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Npgsql;

namespace loja_BD.DAL
{
    public class DataAccessLayer
    {
        static string serverName = "database-andersonsantos.ce7fpddug7vj.us-east-1.rds.amasonaws.com";                                          //localhost
        static string port = "5432";                                                            //porta default
        static string userName = "andersonSantos";                                               //nome do administrador
        static string password = "150492ams";                                             //senha do administrador
        static string databaseName = "projetoBD";                                       //nome do banco de dados
        protected NpgsqlConnection pgsqlConnection = null;
        protected string connString = null;

        public DataAccessLayer()
        {
            this.connString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};", serverName, port, userName, password, databaseName);
        }

        //Host=database-andersonsantos.ce7fpddug7vj.us-east-1.rds.amasonaws.com;Port=5432;Pooling=true;Database=projetoBD;User ID=andersonSantos;Password=150492ams;
    }
}
