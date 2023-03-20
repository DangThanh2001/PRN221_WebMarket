using DataAccess;
using Microsoft.Extensions.Caching.Memory;
using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	public class AccountService
	{
		private IAcountRepository _repository;
		private ITokenService _tokenService;
		private IMemoryCache _memoryCache;
        public AccountService(IAcountRepository repository, ITokenService tokenService, IMemoryCache memoryCache)
		{
			_repository = repository;
			_tokenService = tokenService;
			_memoryCache = memoryCache;
		}

		public bool Login (string username, string password)
		{
			var account = _repository.Login(username, password);
			if(account == null)
			{
				return false;
			}
			if(Common.VerifyPassword(password, account.Password))
			{
				var token = _tokenService.BuildToken(account);
                _memoryCache.Set("Token", token);
                return true;
			}
            return false;
		}
		public int Register(Account account)
		{
			account.Password = Common.HashPassword(account.Password);
			var add = _repository.Register(account);
			return add;
		}
	}
}
