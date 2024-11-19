using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Last_Day_.Dtos.PostDtos
{
    public class Product_Post_Only_Dto
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [Range(0.1, 10000)]
        public double Price { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public IList<int> UserId { get; set; }
    }
}
