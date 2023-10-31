using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataContext
{
    public class DapperORMHelper: IDapperORMHelper

    {
        private readonly IConfiguration _configuration;
        public string ConnectionString { get; set; }
        public string ProviderName { get; }

        public DapperORMHelper(IConfiguration configuration) { 
        
            _configuration = configuration;

            ConnectionString = _configuration.GetConnectionString("DBConnection");
            ProviderName = "System.Data.SqlClient";
        
        }

        public IDbConnection GetDapperContextHelper()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
