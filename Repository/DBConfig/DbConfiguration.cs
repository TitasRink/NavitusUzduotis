using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Navitus.Repository.DBConfig
{
    public class DbConfiguration : IDbConfiguration
    {
        public string ConnectionString { get; set; }
        public DbContextOptions Options { get; set; }

        public DbConfiguration(IConfiguration config)
        {
            ConnectionString = config.GetConnectionString("ConString");
            Options = new DbContextOptionsBuilder().UseSqlServer(ConnectionString).Options;
        }
    }
}
