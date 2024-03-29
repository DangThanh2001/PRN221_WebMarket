﻿using DataAccess;
using DataAccess.Repository;
using DocumentFormat.OpenXml.Office2010.Excel;
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
		private string _token;
        public AccountService(IAcountRepository repository, ITokenService tokenService, IMemoryCache memoryCache)
		{
			_repository = repository;
			_tokenService = tokenService;
			_memoryCache = memoryCache;
		}

		public bool Login (string username, string password)
		{
			try
			{
                var account = _repository.Login(username, password);
                if (account == null)
                {
                    return false;
                }
                if (Common.VerifyPassword(password, account.Password))
                {
                    _token = _tokenService.BuildToken(account);
                    _memoryCache.Set("Token", _token);
                    return true;
                }
				return false;
			}
			catch(Exception ex)
			{
				return false;
			}
			
		}
		
		public string GetAccountId()
		{
            var token = _memoryCache.Get<string>("Token");
			if(token != null)
			{
				var id = _tokenService.GetUserId(token);
				return id;
            }
			return null;
		}
		public int Register(Account account)
		{
			account.Password = Common.HashPassword(account.Password);
			var add = _repository.Register(account);
			return add;
		}
		public bool SignOut()
		{
			_memoryCache.Remove("Token");
			return true;
        }
		public Account? GetAccountById(int id)
		{
			return _repository.GetAccountWithId(id).GetAwaiter().GetResult();
		}
		public int UpdateAccount(Account account)
		{
			return _repository.Update(account);
        }
		public Account GetAccountByEmail(string email)
		{
			return _repository.GetAccountByEmail(email).GetAwaiter().GetResult();
		}
        public int ChangePass(string email,string pass)
        {
			var acc = _repository.GetAccountByEmail(email).GetAwaiter().GetResult();
            
            acc.Password = Common.HashPassword(pass);
            return _repository.Update(acc);
        }
		public int DeleteAccount(int id)
		{
			Account acc = GetAccountById(id);
			acc.IsActive = false;
			return _repository.Update(acc);
		}
        public int Active(int id)
        {
            Account acc = GetAccountById(id);
            acc.IsActive = true;
            return _repository.Update(acc);
        }
        public List<Account> listAllAccount()
		{
			return _repository.getAll();
		}

    }
}
