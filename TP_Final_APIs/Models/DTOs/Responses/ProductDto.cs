using System.ComponentModel.DataAnnotations;

namespace TP_Final_APIs.Models.DTOs.Responses
{
    public class ProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string Description { get; set; }
        public double Discount { get; set; } = 0;
        public bool HappyHour { get; set; } = false;
        public bool Favourite { get; set; } = false;
        public int IdCaterogies { get; set; }
    }
}
