using E_Commerce_Last_Day_.Dtos.GetDtos;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Last_Day_.Dtos.PostDtos
{
    public class Category_Dto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public IList<product_Dto_WithOut_Category> Product_Dto_WithOut_Categories { get; set; }
    }
}
