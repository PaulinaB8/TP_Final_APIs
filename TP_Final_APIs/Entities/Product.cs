using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Final_APIs.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string Description { get; set; }
        public double Discount { get; set; } = 0;
        public bool HappyHour { get; set; } = false;
        public bool Favourite { get; set; } = false;

        [ForeignKey("IdCategory")]
        public Category Category { get; set; }
        public int IdCategory { get; set; }

    }
}
