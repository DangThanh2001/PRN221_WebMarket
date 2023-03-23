using DataAccess.IRepositotry;
using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService
    {
        private IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public List<Product> GetAllProduct()
        {
            return _repository.GetAllProduct();
        }

        public Product GetProductWithId(int id)
        {
            return _repository.GetProductWithId(id);
        }

        public void AddProduct(Product product)
        {
            _repository.AddProduct(product);
        }

        public void UpdateCategory(Product product)
        {
            _repository.UpdateProduct(product);
        }

        public void DeleteCategory(int id)
        {
            _repository.DeleteProduct(id);
        }
    }
}
