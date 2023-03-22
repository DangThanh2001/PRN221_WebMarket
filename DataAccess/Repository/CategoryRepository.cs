
using DataAccess.IRepositotry;
using Microsoft.EntityFrameworkCore;
using ObjectModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

        public List<Category> GetAllCategory()
        {
            return _dbContext.Categories.ToList();
        }

        public Category GetCategoryWithId(int id)
        {
            return _dbContext.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
        }

        public void AddCategory(Category category)
        {
            try
            {
                Category c = GetCategoryWithId(category.CategoryId);
                if (c == null)
                {
                    _dbContext.Categories.Add(c);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new Exception("This Category exists");
            }
        }

        public void UpdateCategory(Category category)
        {
            try
            {
                Category c = GetCategoryWithId(category.CategoryId);
                if (c != null)
                {
                    _dbContext.Entry<Category>(category).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("The category does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteCategory(int id)
        {
            try
            {
                Category c = GetCategoryWithId(id);
                if (c != null)
                {

                    _dbContext.Categories.Remove(c);
                    _dbContext.SaveChanges();

                }
            }
            catch (Exception)
            {
                throw new Exception("The category doesn't exist");
            }
        }
        public string GetCategoryNameWithCategoryId(int CategoryId)
        {
            return _dbContext.Categories.Where(x => x.CategoryId == CategoryId).FirstOrDefault().CategoryName;
        }

    }
}
