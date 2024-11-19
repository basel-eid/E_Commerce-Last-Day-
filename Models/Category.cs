using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Last_Day_.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public IList<Product>? Products { get; set; }
    }
}
