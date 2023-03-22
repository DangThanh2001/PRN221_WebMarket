using DataAccess;
using DataAccess.IRepositotry;
using Microsoft.Extensions.Caching.Memory;
using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Product_DetailService
    {
        private IProduct_DetailRepository _product_detail;
        private ICategoryRepository _categoryRepository;
        public Product_DetailService(IProduct_DetailRepository product_detail, ICategoryRepository categoryRepository)
        {
            _product_detail = product_detail;
            _categoryRepository = categoryRepository;
        }
        public Product GetProductById(int id)
        {
            var product = _product_detail.GetProductWithId(id);
            return product;
        }
        public List<string> GetCategoryName(List<string> cate_cut)
        {
            List<string> name = new List<string>();
            foreach (var cate in cate_cut)
            {
                name.Add(_categoryRepository.GetCategoryNameWithCategoryId(int.Parse(cate)));

            }
            return name;

        }
    }
}
