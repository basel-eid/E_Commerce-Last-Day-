using E_Commerce_Last_Day_.Models;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Last_Day_.Dtos.GetDtos
{
    public class Product_Dto_For_User
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [Range(0.1, 10000)]
        public double Price { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public Category_Dto_GetOnlyCategory Category { get; set; }
    }
}
