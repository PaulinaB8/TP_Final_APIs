using System.ComponentModel.DataAnnotations;
using TP_Final_APIs.Entities;

namespace TP_Final_APIs.Models.DTOs.Responses
{
    public class UserDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(8)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Mail { get; set; }
        public bool Status { get; set; } = true;
        [Phone]
        public string Phone { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
