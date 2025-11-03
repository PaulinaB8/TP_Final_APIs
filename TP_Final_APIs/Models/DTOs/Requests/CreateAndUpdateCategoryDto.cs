using System.ComponentModel.DataAnnotations;
using TP_Final_APIs.Entities;

namespace TP_Final_APIs.Models.DTOs.Requests
{
    public class CreateAndUpdateCategoryDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public IEnumerable<int>? ProductsId { get; set; }
    }
}
