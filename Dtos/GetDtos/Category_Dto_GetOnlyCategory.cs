using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Last_Day_.Dtos.GetDtos
{
    public class Category_Dto_GetOnlyCategory
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
