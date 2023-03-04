using Microsoft.EntityFrameworkCore;
using ObjectModel;

namespace DataAccess
{
    public class DbContextBase : DbContext
    {
        public DbContextBase(DbContextOptions<DbContextBase> options):base(options) 
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}