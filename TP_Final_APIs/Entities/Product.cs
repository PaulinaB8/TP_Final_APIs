namespace TP_Final_APIs.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public bool Discount { get; set; }
        public bool HappyHour { get; set; }
        public bool Favourite { get; set; }
        public int IdCaterogies { get; set; }

    }
}
