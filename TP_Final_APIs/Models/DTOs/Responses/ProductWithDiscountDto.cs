using System.ComponentModel.DataAnnotations;

namespace TP_Final_APIs.Models.DTOs.Responses
{
    public class ProductWithDiscountDto

    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public double Discount { get; set; } = 0;
        public bool HappyHour { get; set; }
        public bool Favourite { get; set; }
        public double FinalPrice { get; set; }
    }
}
