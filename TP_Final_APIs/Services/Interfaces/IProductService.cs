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
         void DeleteProduct(int idProduct);
         void UpdateProduct(UpdateProductDto updatedProduct, int idProduct);
         void ChangeDiscount(double discount, int idProduct);
         string ApplyHappyHour(int idProduct);
    }
}
