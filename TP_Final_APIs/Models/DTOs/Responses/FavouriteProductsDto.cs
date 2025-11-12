using System.ComponentModel.DataAnnotations;

namespace TP_Final_APIs.Models.DTOs.Responses
{
    public class FavouriteProductsDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        
        
    }
}
