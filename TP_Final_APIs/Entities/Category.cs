using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Final_APIs.Entities;

public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    public ICollection<Product>? Products { get; set; } = new List<Product>();
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
}
