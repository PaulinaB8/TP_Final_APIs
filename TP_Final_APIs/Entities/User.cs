using System.ComponentModel.DataAnnotations;

namespace TP_Final_APIs.Entities;

public class User
{
    public int Id {  get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Password {  get; set; }
    [Required]
    public string Mail {  get; set; }
    public bool Status { get; set; } = true;
    public string Phone { get; set; }

    public IEnumerable<Category> Categories { get; set; }
}
