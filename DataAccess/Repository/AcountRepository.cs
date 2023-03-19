using Microsoft.EntityFrameworkCore;
using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{

	public class AcountRepository : IAcountRepository
	{
        private readonly DbContextBase _dbContext;
		public AcountRepository(DbContextBase dbContext)
		{
			_dbContext = dbContext;
		}
        public Task<Account> GetAccountByName(string name)
		{
			throw new NotImplementedException();
		}

		public Task<Account> GetAccountWithId(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Account>> GetAllAcount()
		{
			throw new NotImplementedException();
		}

		public Account? Login(string username, string password)
		{
			return _dbContext.Accounts
                .Where(x => x.Email.Equals(username)).FirstOrDefault();
        }

        public int Register(Account account)
        {
			account.Balance = 0;
			account.DayCreated= DateTime.Now;
			account.FirstName = "";
			_dbContext.AddAsync(account);
            var add =  _dbContext.SaveChanges();
			return add;
        }
    }
}
