using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ICategoryRepository
    {
        public List<Category> GetAllCategory();
        public Category GetCategoryWithId(int id);
        public void AddCategory(Category category);
        public void UpdateCategory(Category category);
        public void DeleteCategory(int id);
        public string GetCategoryNameWithCategoryId(int CategoryId);

    }
}
