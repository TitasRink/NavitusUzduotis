using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository.SqlDB
{
    public class SqlConnection: DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientHistory> ClientHistory { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=localhost;Database=Uzduotis;Trusted_Connection=True;");
        }
    }
}
