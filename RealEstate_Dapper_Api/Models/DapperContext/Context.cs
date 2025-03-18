using System.Data;
using Microsoft.Data.SqlClient;

namespace RealEstate_Dapper_Api.Models.DapperContext
{
    public class Context
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;


        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("connection");
        }

        //Microsoft.Data.SqlClient olanı kurduk
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);


    }
}
