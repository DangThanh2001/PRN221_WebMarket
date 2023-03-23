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
        public List<Company> GetAllCompany()
        {
        
            return _dbContext.Companys.ToList();
        }
        public Company GetCompanyWithId(int id)
        {
            return _dbContext.Companys.Where(x => x.CompanyId == id).FirstOrDefault();
        }
        public void AddCompany(Company company)
        {
            try
            {
                Company c = GetCompanyWithId(company.CompanyId);
                if (c == null)
                {
                    _dbContext.Companys.Add(c);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new Exception("This Company exists");
            }
        }
        public void UpdateCompany(Company company)
        {
            try
            {
                Company c = GetCompanyWithId(company.CompanyId);
                if (c != null)
                {
                    _dbContext.Entry<Company>(company).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("The company does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void DeleteCompany(int id)
        {
            try
            {
                Company c = GetCompanyWithId(id);
                if (c != null)
                {

                    _dbContext.Companys.Remove(c);
                    _dbContext.SaveChanges();

                }
            }
            catch (Exception)
            {
                throw new Exception("The Company doesn't exist");
            }
        }
    }
}
