
using System.Collections.Generic;
using Catalog.Entities;

public interface IAccountRepository
    {
        Account GetAccount(int id);
        IEnumerable<Account> GetAccounts();

		void CreateAccount(Account account);

		void UpdateAccount(Account account);

		void DeleteAccount(Account account);
    }
