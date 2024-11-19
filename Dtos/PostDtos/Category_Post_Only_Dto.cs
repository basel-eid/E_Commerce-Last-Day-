using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Last_Day_.Dtos.PostDtos
{
    public class Category_Post_Only_Dto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public IList<int> ProductsId { get; set; }
    }
}
