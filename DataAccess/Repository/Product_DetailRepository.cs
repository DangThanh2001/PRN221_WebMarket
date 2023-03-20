using Microsoft.EntityFrameworkCore;
using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class Product_DetailRepository : IProduct_DetailRepository
    {
        private readonly DbContextBase _dbContext;
        public Product_DetailRepository(DbContextBase dbContext)
        {
            _dbContext = dbContext;
        }
        public Product GetProductWithId(int productId)
        {
          return  _dbContext.Products.Where(x => x.ProductId == productId).FirstOrDefault();
        }

    }
}
