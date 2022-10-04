
using System.Collections.Generic;
using System.Linq;
using Catalog.Dtos;
using Catalog.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
	[ApiController]
	[Route("Api/[controller]")]
	public class AccountController : ControllerBase
	{
		private readonly IAccountRepository repository;
		private int IdNumber = 1;

		public AccountController(IAccountRepository repository)
		{
			this.repository = repository;
		}

		[HttpGet]
		public IEnumerable<AccountDto> getAccounts()
		{
			var accounts = repository.GetAccounts().Select(item => item.AsDto());

			return accounts;
		}

		[HttpGet("{id}")]
		public ActionResult<AccountDto> getAccount(int id)
		{
			var account = repository.GetAccount(id);

			if (account == null)
			{
				return NotFound();
			}

			return account.AsDto();
		}

		[HttpPut("{id}")]
		public ActionResult updateAccount(int id, UpdateAccountDto accountDto)
		{
			var existingAccount = repository.GetAccount(id);

			if (existingAccount == null)
			{
				return NotFound();
			}

			Account updatedAccount = existingAccount with
			{
				FirstName = accountDto.FirstName,
				LastName = accountDto.LastName,
				Password = accountDto.Password,
			};

			repository.UpdateAccount(updatedAccount);

			return NoContent();
		}
		[HttpDelete("{id}")]
		public ActionResult deleteAccount(int id)
		{
			var existingAccount = repository.GetAccount(id);

			if(existingAccount == null){
				return NotFound();
			}

			repository.DeleteAccount(existingAccount);
			return NoContent();
		}

		[HttpPost]
		public ActionResult<AccountDto> createAccount(CreateAccountDto createAccountDto)
		{
			var accountSize = repository.GetAccounts().Count();

			Account acc = new Account()
			{
				Id = accountSize+1,
				FirstName = createAccountDto.FirstName,
				LastName  = createAccountDto.LastName,
				Password  = createAccountDto.Password,
				UserName  = createAccountDto.FirstName+createAccountDto.LastName
			};

			repository.CreateAccount(acc);
			return CreatedAtAction(nameof(getAccount),new {id = acc.Id},acc.AsDto());
		}
	}

}