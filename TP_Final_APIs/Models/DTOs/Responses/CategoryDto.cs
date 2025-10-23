using System.ComponentModel.DataAnnotations;
using TP_Final_APIs.Entities;

namespace TP_Final_APIs.Models.DTOs.Responses
{
    public class CategoryDto
    {
        [Required]
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
