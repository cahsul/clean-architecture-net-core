using Application.X.Interfaces.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Persistence.DbContexts
{
    /// <summary>
    /// databse TODO menggunakan dapper
    /// </summary>
    public class TodoDbContextDapper : ITodoDbContextDapper
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public TodoDbContextDapper(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = "Data Source=194.233.70.37,7433;Initial Catalog=Todo;User ID=sa;Password=Cay.12123;";
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
