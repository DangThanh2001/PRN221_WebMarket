using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public interface IAcountRepository
	{
		public Task<IEnumerable<Account>> GetAllAcount();
		public Account? Login(string username, string password);
		public Task<Account> GetAccountWithId(int id);
		public Task<Account> GetAccountByName(string name);
		public int Register(Account account);
	}
}