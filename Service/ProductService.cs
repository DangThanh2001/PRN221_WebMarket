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

        private IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public List<Product> GetAllProduct()
        {
            return productRepository.GetAllProduct();
        }

        public Product GetProductWithId(int id)
        {
            return productRepository.GetProductWithId(id);
        }

        public void AddProduct(Product product)
        {
            productRepository.AddProduct(product);
        }

        public void UpdateCategory(Product product)
        {
            productRepository.UpdateProduct(product);
        }

        public void DeleteCategory(int id)
        {
            productRepository.DeleteProduct(id);
        }

        public List<Product> listAllProduct()
        {
            return productRepository.GetAllProduct();
        }
    }
}
