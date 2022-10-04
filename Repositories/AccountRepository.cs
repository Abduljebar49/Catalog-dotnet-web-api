
using System.Collections.Generic;
using System.Linq;
using Catalog.Entities;

namespace Catalog.Repositories
{

    public class AccountRepository : IAccountRepository
    {
        public readonly List<Account> accounts = new()
        {
            new Account
            {
                Id = 1,
                FirstName = "Abduljebar",
                LastName = "Sani",
                UserName = "username",
                Password = "123456",
            },
            new Account
            {
                Id = 2,
                FirstName = "Abdulj123",
                LastName = "Sani123",
                UserName = "username123",
                Password = "123456",
            },
            new Account
            {
                Id = 3,
                FirstName = "Abduljebar321",
                LastName = "Sani321",
                UserName = "username321",
                Password = "123456",
            },
        };

        public IEnumerable<Account> GetAccounts()
        {
            return accounts;
        }

        public Account GetAccount(int id)
        {
            return accounts.Where(account => account.Id == id).SingleOrDefault();
        }

		public void CreateAccount(Account account)
		{
			accounts.Add(account);
		}

		public void UpdateAccount(Account account)
		{
			var index = accounts.FindIndex(existingItem => existingItem.Id == account.Id);

			accounts[index] = account;
		}

		public void DeleteAccount(Account account){
			var index = accounts.FindIndex(index=>index.Id == account.Id);
			accounts.RemoveAt(index);
		}

    }
}