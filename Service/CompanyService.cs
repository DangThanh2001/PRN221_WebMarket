using DataAccess.IRepositotry;
using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CompanyService
    {
        private ICompanyRepository _repository;
        public CompanyService(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public List<Company> GetAllCompany()
        {
            return _repository.GetAllCompany();
        }

        public Company GetCompanyWithId(int id)
        {
            return _repository.GetCompanyWithId(id);
        }

        public void AddCompany(Company company)
        {
            _repository.AddCompany(company);
        }

        public void UpdateCompany(Company company)
        {
            _repository.UpdateCompany(company);
        }

        public void DeleteCompany(int id)
        {
            _repository.DeleteCompany(id);
        }


    }
}
