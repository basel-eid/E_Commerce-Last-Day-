using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Last_Day_.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [Range(0.1,10000)]
        public double Price { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public IList<User> Users { get; set;}
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
