using TP_Final_APIs.Entities;

namespace TP_Final_APIs.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProductsByCategory(int idCategory);
        public Product GetProduct(int idProduct);
        public IEnumerable<Product> GetFavouriteProducts(string userName);
        public IEnumerable<Product> GetDiscountProducts(string userName);
        public IEnumerable<Product> GetHappyHourProducts(string userName);
        public void CreateProduct(Product newProduct);
        public void DeleteProduct(int idProduct);
        public void UpdateProduct(Product updatedProduct);
        public void ChangeDiscount(double discount, int idProduct);
        public string ApplyHappyHour(int idProduct);

        public int? GetProductByName(string productName);
    }
}
