using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
	public class CreateAccountDto{
		[Required]
        public string FirstName { get; set; }
		[Required]
        public string LastName { get; set; }
		[Required]
        public string Password { get; set; }

	}
}