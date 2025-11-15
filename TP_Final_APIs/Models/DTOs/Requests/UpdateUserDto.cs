using System.ComponentModel.DataAnnotations;

namespace TP_Final_APIs.Models.DTOs.Requests
{
    public class UpdateUserDto
    {
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

      

        [EmailAddress]
        public string? Mail { get; set; }

        [Phone]
        public string? Phone { get; set; }

        public bool Status { get; set; } = true;
    }
}
