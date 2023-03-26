using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepositotry
{
    public interface IProductRepository
    {
        public List<Product> GetAllProduct();
        public Product GetProductWithId(int id);
        public List<Product> GetProductWithUserId(int id);
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(int id);
    }
}
