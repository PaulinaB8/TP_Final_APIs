using TP_Final_APIs.Entities;

namespace TP_Final_APIs.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProductsByCategory(int idCategory);
        public Product GetProduct(int idProduct);
        public IEnumerable<Product> GetFavouriteProducts();
        public IEnumerable<Product> GetDiscountProducts();
        public IEnumerable<Product> GetHappyHourProducts();
        public void CreateProduct(Product newProduct);
        public void DeleteProduct(int idProduct);
        public void UpdateProduct(Product updatedProduct, int idProduct);
        public void ChangeDiscount(double discount, int idProduct);
        public string ApplyHappyHour(int idProduct);

        public int? GetProductByName(string productName);
    }
}
