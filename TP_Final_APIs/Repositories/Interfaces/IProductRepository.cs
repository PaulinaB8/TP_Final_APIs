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
    }
}
