using DataAccess.IRepositotry;
using Microsoft.EntityFrameworkCore;
using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContextBase _dbContext;
        public ProductRepository(DbContextBase dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Product> GetAllProduct()
        {
            return _dbContext.Products.ToList();
        }
        public Product GetProductWithId(int id)
        {
            return _dbContext.Products.Where(x => x.ProductId == id).FirstOrDefault();
        }
        public void AddProduct(Product product)
        {
            try
            {
                Product p = GetProductWithId(product.ProductId);
                if (p == null)
                {
                    _dbContext.Products.Add(p);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new Exception("This Product exists");
            }
        }
        public void UpdateProduct(Product product)
        {
            try
            {
                Product p = GetProductWithId(product.ProductId);
                if (p != null)
                {
                    _dbContext.Entry<Product>(product).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("The Product does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void DeleteProduct(int id)
        {
            try
            {
                Product c = GetProductWithId(id);
                if (c != null)
                {

                    _dbContext.Products.Remove(c);
                    _dbContext.SaveChanges();

                }
            }
            catch (Exception)
            {
                throw new Exception("The Product doesn't exist");
            }
        }
    }
}
