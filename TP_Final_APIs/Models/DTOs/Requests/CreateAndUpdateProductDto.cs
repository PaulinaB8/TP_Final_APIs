using System.ComponentModel.DataAnnotations;

namespace TP_Final_APIs.Models.DTOs.Requests
{
    public class CreateAndUpdateProductDto
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string Description { get; set; }
        public bool Discount { get; set; } = false;
        public bool HappyHour { get; set; } = false;
        public bool Favourite { get; set; } = false;
        public int IdCaterogies { get; set; }
    }
}
