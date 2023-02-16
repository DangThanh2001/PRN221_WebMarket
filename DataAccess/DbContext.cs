using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DbContextBase : DbContext
    {
        public DbContextBase(DbContextOptions<DbContextBase> options):base(options) { }

    }
}