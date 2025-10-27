using TP_Final_APIs.Entities;
using TP_Final_APIs.Repositories.Interfaces;

namespace TP_Final_APIs.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        List<Product> _context = new List<Product>();
        public IEnumerable<Product> GetProductsByCategory(int idCategory)
        {
            return _context.Where(x => x.IdCaterogies ==idCategory).ToList();
        }
        public Product GetProduct(int idProduct)
        {
            return _context.FirstOrDefault(x => x.Id == idProduct);
        }
        public IEnumerable<Product> GetFavouriteProducts()
        {
            return _context.Where(x => x.Favourite == true).ToList();
        }
        public IEnumerable<Product> GetDiscountProducts()
        {
            return _context.Where(x => x.Discount == true).ToList();
        }
        public IEnumerable<Product> GetHappyHourProducts()
        {
            return _context.Where(x => x.HappyHour == true).ToList();
        }

        public void CreateProduct(Product newProduct)
        {
            _context.Add(newProduct);
        }
        public void DeleteProduct(int idProduct)
        {
            _context.Remove(GetProduct(idProduct));
        }
        public void UpdateProduct(Product updatedProduct, int idProduct)
        {
            
        }
        public string ChangeDiscount(double discount, int idProduct)
        {
            var productToChange = GetProduct(idProduct);
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
        public string ApplyHappyHour(int idProduct)
        {
            var productToChange = GetProduct(idProduct);
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
