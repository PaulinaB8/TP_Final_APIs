using TP_Final_APIs.Data;
using TP_Final_APIs.Entities;
using TP_Final_APIs.Repositories.Interfaces;

namespace TP_Final_APIs.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly TpFinalContexts _context;
        public IEnumerable<Product> GetProductsByCategory(int idCategory)
        {
            return _context.Products.Where(x => x.IdCategory == idCategory).ToList();
        }
        public Product GetProduct(int idProduct)
        {
            return _context.Products.FirstOrDefault(x => x.Id == idProduct);
        }
        public IEnumerable<Product> GetFavouriteProducts()
        {
            return _context.Products.Where(x => x.Favourite == true).ToList();
        }
        public IEnumerable<Product> GetDiscountProducts()
        {
            return _context.Products.Where(x => x.Discount > 0).ToList();
        }


        public IEnumerable<Product> GetHappyHourProducts()
        {
            return _context.Products.Where(x => x.HappyHour == true).ToList();
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
            _context.Products.Update(updatedProduct);
        }


        public void ChangeDiscount(double discount, int idProduct)
        {
            var productToChange = GetProduct(idProduct);
            productToChange.Discount = discount;
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
