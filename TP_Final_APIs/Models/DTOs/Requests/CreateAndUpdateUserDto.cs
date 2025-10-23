using System.ComponentModel.DataAnnotations;
using TP_Final_APIs.Entities;

namespace TP_Final_APIs.Models.DTOs.Requests
{
    public class CreateAndUpdateUserDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Mail { get; set; }
        public bool Status { get; set; } = true;
        public string Phone { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
