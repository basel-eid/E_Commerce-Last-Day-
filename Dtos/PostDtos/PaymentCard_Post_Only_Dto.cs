using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Last_Day_.Dtos.PostDtos
{
    public class PaymentCard_Post_Only_Dto
    {
        public string CardholderName { get; set; }
        [Required]
        //[CreditCard]
        public int CreditCardId { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; } = DateTime.UtcNow;
        public int UserId { get; set; }
    }
}
