using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Last_Day_.Dtos.GetDtos
{
    public class PaymentCard_Dto_Only
    {
        public string CardholderName { get; set; }
        [Required]
        //[CreditCard]
        public int CreditCardNum { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; } = DateTime.UtcNow;
    }
}
