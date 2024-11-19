using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace E_Commerce_Last_Day_.Dtos.GetDtos
{
    public class User_WithOut_Product_Dto
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
        public PaymentCard_Dto_Only PaymentCard_Dto_Only { get; set; }
    }
}
