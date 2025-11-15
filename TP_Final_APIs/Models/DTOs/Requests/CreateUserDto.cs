using System.ComponentModel.DataAnnotations;
using TP_Final_APIs.Entities;

namespace TP_Final_APIs.Models.DTOs.Requests
{
    public class CreateUserDto

    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Mail { get; set; }
    
        [Phone]
        public string Phone { get; set; }

   
    }
}
