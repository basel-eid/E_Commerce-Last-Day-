using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace E_Commerce_Last_Day_.Models
{
    public class PaymentCard
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string CardholderName { get; set; }
        [Required]
        //[CreditCard]
        public int CreditCardNum { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        public User User { get; set; }
    }
}
