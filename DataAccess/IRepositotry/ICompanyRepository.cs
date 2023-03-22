using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ICompanyRepository
    {
        public List<Company> GetAllCompany();
        public Company GetCompanyWithId(int id);
        public void AddCompany(Company company);
        public void UpdateCompany(Company company);
        public void DeleteCompany(int id);
      public string GetCompanyNameWithCompanyId(int companyId);
    }
}
