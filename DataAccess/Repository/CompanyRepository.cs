using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DbContextBase _dbContext;
        public CompanyRepository(DbContextBase dbContext)
        {
            _dbContext = dbContext;
        }
        public string GetCompanyNameWithCompanyId(int companyId)
        {
            return _dbContext.Companys.Where(x => x.CompanyId == companyId).FirstOrDefault().Name;
        }
    }
}
