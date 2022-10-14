using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.QueryDatabaseConfiguration
{
    public abstract class ConnectionString
    {
        protected readonly string connection;
        public ConnectionString(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("DBConnectionString");
        }
    }
}
