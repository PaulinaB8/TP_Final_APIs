using TP_Final_APIs.Entities;

namespace TP_Final_APIs.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public IEnumerable<Product> getProductsByCategory(int idCategory);
        public Product getProduct(int idProduct);
        public IEnumerable<Product> getFavouriteProducts();
        public IEnumerable<Product> getDiscountProducts();
        public IEnumerable<Product> getHappyHourProducts();
        public void createProduct(Product newProduct);
        public void deleteProduct(int idProduct);
        public void updateProduct(Product updatedProduct, int idProduct);
        public string changeDiscount(double discount, int idProduct);
        public string applyHappyHour(int idProduct);
    }
}
