using Catalog.Dtos;
using Catalog.Entities;

namespace Catalog
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate,
            };
        }

        public static AccountDto AsDto(this Account account)
        {
            return new AccountDto
            {
                Id = account.Id,
                FirstName = account.FirstName,
                LastName  = account.LastName,
                UserName  = account.UserName,
                Password  = account.Password,
            };
        }

    }
}