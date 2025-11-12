using System.ComponentModel.DataAnnotations;
using TP_Final_APIs.Entities;

namespace TP_Final_APIs.Models.DTOs.Requests
{
    public class UpdateCategoryDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public ICollection<ProductToListDto>? Products { get; set; } = new List<ProductToListDto>();
        public int UserId { get; set; }
    }
}
