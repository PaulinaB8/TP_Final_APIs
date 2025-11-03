using System.ComponentModel.DataAnnotations;

namespace TP_Final_APIs.Models.DTOs.Requests;

public class CredetialDtoRequest
{
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    
}

