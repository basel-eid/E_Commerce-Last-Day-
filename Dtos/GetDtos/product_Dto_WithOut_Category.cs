using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Last_Day_.Dtos.GetDtos
{
    public class product_Dto_WithOut_Category
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [Range(0.1, 10000)]
        public double Price { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public IList<User_WithOut_Product_Dto> User_WithOut_Product_Dtos { get; set; }
    }
}
