using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace FolhaBack.Repositories
{
    public class Repository
    {
        private IConfiguration configuration;
        public Repository (IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public MySqlConnection GetConnection() 
        {
            return new MySqlConnection(configuration.GetValue<string>("DBInfo:ConnectionString"));
        }
    }
}