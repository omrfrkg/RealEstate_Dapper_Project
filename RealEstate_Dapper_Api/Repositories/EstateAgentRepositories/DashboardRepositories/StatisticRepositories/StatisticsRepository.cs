using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly Context _context;

        public StatisticsRepository(Context context)
        {
            _context = context;
        }

        public int AllProductCount()
        {
            string query = "Select Count(*) From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }

        }

        public int ProductCountByEmployeeId(int id)
        {
            var query = "Select Count(*) From Product Where EmployeeId = @EmployeeId";
            var parameters = new DynamicParameters();
            parameters.Add("EmployeeId", id); // Replace with actual employee ID
            using(var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, parameters);
                return values;
            }
        }

        public int ProductCountByStatusFalse(int id)
        {
            var query = "Select Count(*) From Product Where EmployeeId = @EmployeeId and ProductStatus = 0";
            var parameters = new DynamicParameters();
            parameters.Add("EmployeeId", id); // Replace with actual employee ID
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, parameters);
                return values;
            }
        }

        public int ProductCountByStatusTrue(int id)
        {
            var query = "Select Count(*) From Product Where EmployeeId = @EmployeeId and ProductStatus = 1";
            var parameters = new DynamicParameters();
            parameters.Add("EmployeeId", id); // Replace with actual employee ID
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, parameters);
                return values;
            }
        }
    }
}
