using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using TP_Final_APIs.Models.DTOs.Requests;
using TP_Final_APIs.Models.DTOs.Responses;

namespace TP_Final_APIs.Services.Interfaces
{
    public interface IProductService
    {
         IEnumerable<ProductDto> GetProductsByCategory(string categoryName);
         ProductDto GetProduct(string productName);
         IEnumerable<ProductDto> GetFavouriteProducts();
         IEnumerable<ProductDto> GetDiscountProducts();
         IEnumerable<ProductDto> GetHappyHourProducts();

        void CreateProduct(CreateProductDto newProduct, string categoryName);
         void DeleteProduct(string productName);
         void UpdateProduct(UpdateProductDto updatedProduct, string productName);
         void ChangeDiscount(double discount, string productName);
         string ApplyHappyHour(string productName);
<<<<<<< HEAD
        ProductDto GetProductWithDiscount(string productName);
        ProductPriceDto GetProductFinalPrice(string productName);
=======
        void ApplyDiscountToProducts(List<string> productNames, double percentage);
>>>>>>> 3bb738d2b0e082a41b14f7d7194d0122ad04bdeb
    }
}
