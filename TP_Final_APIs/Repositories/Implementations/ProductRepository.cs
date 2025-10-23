using TP_Final_APIs.Entities;
using TP_Final_APIs.Repositories.Interfaces;

namespace TP_Final_APIs.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        List<Product> _context = new List<Product>();
        public IEnumerable<Product> getProductsByCategory(int idCategory)
        {
            return _context.Where(x => x.IdCaterogies ==idCategory).ToList();
        }
        public Product getProduct(int idProduct)
        {
            return _context.FirstOrDefault(x => x.Id == idProduct);
        }
        public IEnumerable<Product> getFavouriteProducts()
        {
            return _context.Where(x => x.Favourite == true).ToList();
        }
        public IEnumerable<Product> getDiscountProducts()
        {
            return _context.Where(x => x.Discount == true).ToList();
        }
        public IEnumerable<Product> getHappyHourProducts()
        {
            return _context.Where(x => x.HappyHour == true).ToList();
        }
    }
}
