using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Final_APIs.Entities;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
