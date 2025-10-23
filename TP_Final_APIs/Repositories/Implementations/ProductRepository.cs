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

        public void createProduct(Product newProduct)
        {
            _context.Add(newProduct);
        }
        public void deleteProduct(int idProduct)
        {
            _context.Remove(getProduct(idProduct));
        }
        public void updateProduct(Product updatedProduct, int idProduct)
        {
            
        }
        public string changeDiscount(double discount, int idProduct)
        {
            var productToChange = getProduct(idProduct);
            if (productToChange.Discount == true)
            {
                productToChange.Discount = false;
                return "El descuento se desactivó";
            }
            else
            {
                productToChange.Discount = true;
                return "El descuento se desactivó";
            }
            
        }
        public string applyHappyHour(int idProduct)
        {
            var productToChange = getProduct(idProduct);
            if (productToChange.HappyHour == true)
            {
                productToChange.HappyHour = false;
                return "El Happy Hour se desactivó";
            }
            else
            {
                productToChange.HappyHour = true;
                return "El Happy Hour se activó ";
            }
        }
    }
}
