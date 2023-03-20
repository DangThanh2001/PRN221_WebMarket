using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbContextBase _dbContext;
        public CategoryRepository(DbContextBase dbContext)
        {
            _dbContext = dbContext;
        }
        public string GetCategoryNameWithCategoryId(int CategoryId)
        {
            return _dbContext.Categories.Where(x => x.CategoryId == CategoryId).FirstOrDefault().CategoryName;
        }
    }
}
