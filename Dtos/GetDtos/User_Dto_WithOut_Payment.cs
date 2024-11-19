using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace E_Commerce_Last_Day_.Dtos.GetDtos
{
    public class User_Dto_WithOut_Payment
    {
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [PasswordPropertyText]
        [MinLength(6)]
        public string? Password { get; set; }
        public IList<Product_Dto_For_User> Product_Dto_For_Users { get; set; }
    }
}
