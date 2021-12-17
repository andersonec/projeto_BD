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
        protected string serverName = "database-andersonsantos.ce7fpddug7vj.us-east-1.rds.amazonaws.com";                                          //localhost
        protected string port = "5432";                                                            //porta default
        protected string userName = "andersonSantos";                                               //nome do administrador
        protected string password = "150492ams";                                             //senha do administrador
        protected string databaseName = "projetoBD";                                       //nome do banco de dados
        protected NpgsqlConnection pgsqlConnection = null;
        protected string connString1 = null;

        public DataAccessLayer()
        {
            this.connString1 = String.Format("Host={0};Port={1};Database={4};User Id={2};Password={3};", serverName, port, userName, password, databaseName);
        }
    }
}
