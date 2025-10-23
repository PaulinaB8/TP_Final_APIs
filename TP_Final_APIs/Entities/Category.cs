namespace TP_Final_APIs.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Product> products { get; set; }
    }
}
