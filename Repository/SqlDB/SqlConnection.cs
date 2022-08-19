using Microsoft.EntityFrameworkCore;
using Navitus.Repository.DBConfig;
using Repository.Entities;

namespace Repository.SqlDB
{
    public class SqlConnection : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientHistory> ClientHistory { get; set; }
    
        public SqlConnection(IDbConfiguration options) : base(options.Options)
        {

        }
    }
}
