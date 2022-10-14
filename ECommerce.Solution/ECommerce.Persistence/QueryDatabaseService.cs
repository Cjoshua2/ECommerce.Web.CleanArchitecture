using DapperExtensions;
using ECommerce.Application.Contract;
using ECommerce.Domain.Common;
using ECommerce.Persistence.QueryDatabaseConfiguration;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Persistence
{
    public class QueryDatabaseService<T> : ConnectionString, IQueryDatabaseService<T> where T : class, IEntity
    {
        public QueryDatabaseService(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using var dbConnection = new SqlConnection(connection);

            return await dbConnection.GetListAsync<T>();
        }

        public async Task<T> GetById(int id)
        {
            using var dbConnection = new SqlConnection(connection);

            return await dbConnection.GetAsync<T>(id);
        }
    }
}
