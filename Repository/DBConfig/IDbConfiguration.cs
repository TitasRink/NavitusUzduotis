using Microsoft.EntityFrameworkCore;

namespace Navitus.Repository.DBConfig
{
    public interface IDbConfiguration
    {
        string ConnectionString { get; set; }
        DbContextOptions Options { get; set; }
    }
}