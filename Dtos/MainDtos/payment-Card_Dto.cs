using E_Commerce_Last_Day_.Dtos.GetDtos;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Last_Day_.Dtos.PostDtos
{
    public class payment_Card_Post_Dto
    {
        public string CardholderName { get; set; }
        [Required]
        //[CreditCard]
        public int CreditCardId { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; } = DateTime.UtcNow;
        public User_Dto_WithOut_Payment User_Dto_WithOut_Payment { get; set; }
    }
}
