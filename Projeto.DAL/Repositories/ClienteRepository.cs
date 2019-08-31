using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Projeto.DAL.Contracts;
using Projeto.DAL.Entities;
using System.Data.SqlClient;
using Dapper;

namespace Projeto.DAL.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string connectionString;

        public ClienteRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["aula"].ConnectionString;
        }
        public void Insert(Cliente obj)
        {
            var query = "insert into Cliente(Nome, Email) values(@Nome, @Email)";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }
        public void Update(Cliente obj)
        {
            var query = "update Cliente set Nome=@Nome, Email=@Email where IdCliente=@IdCliente";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }
        public void Delete(int id)
        {
            var query = "delete from Cliente where IdCliente=@IdCliente";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, new { IdCliente = id });
            }
        }

        public List<Cliente> SelectAll()
        {
            var query = "select * from Cliente";
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Cliente>(query).ToList();
            }
        }
        public Cliente SelectById(int id)
        {
            var query = "select * from Cliente where IdCliente=@IdCliente";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Cliente>(query, new { IdCliente = id }).SingleOrDefault();
            }
        }
        public Cliente SelectByEmail(string email)
        {
            var query = "select * from Cliente where Email=@Email";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Cliente>(query, new { Email = email }).SingleOrDefault();
            }
        }
    }
}
