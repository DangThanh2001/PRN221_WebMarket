using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IProduct_DetailRepository
    {
        public Product GetProductWithId(int productId);
        
    }
}
