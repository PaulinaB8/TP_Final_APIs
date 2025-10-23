using System.ComponentModel.DataAnnotations;

namespace TP_Final_APIs.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
