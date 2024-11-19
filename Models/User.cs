using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Last_Day_.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set;}
        [Required]
        [PasswordPropertyText]
        [MinLength(6)]
        public string? Password { get; set; }   
        public PaymentCard? PaymentCard { get; set; }
        public int PaymentCardId { get; set; }
        public IList<Product>? Products { get; set; }
    }
}
