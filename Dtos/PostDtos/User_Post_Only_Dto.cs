using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace E_Commerce_Last_Day_.Dtos.PostDtos
{
    public class User_Post_Only_Dto
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
        public IList<int> ProductId { get; set; }
        public int PaymentCardId { get; set; }
    }
}
