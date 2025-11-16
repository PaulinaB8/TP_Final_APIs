using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using TP_Final_APIs.Models.DTOs.Requests;
using TP_Final_APIs.Models.DTOs.Responses;

namespace TP_Final_APIs.Services.Interfaces
{
    public interface IProductService
    {
         IEnumerable<ProductDto> GetProductsByCategory(string categoryName, string userName);
         ProductDto GetProduct(string productName, string userName);
         IEnumerable<FavouriteProductsDto> GetFavouriteProducts(string userName);
         IEnumerable<ProductsWithDiscountDto> GetDiscountProducts(string userName);
         IEnumerable<FavouriteProductsDto> GetHappyHourProducts(string userName);

        string? CreateProduct(CreateProductDto newProduct, string categoryName, int userId);
        public bool DeleteProduct(string productName, int userId);
         void UpdateProduct(UpdateProductDto updatedProduct, string productName);
         void ChangeDiscount(double discount, string productName);
         string ApplyHappyHour(string productName);

        ProductWithDiscountDto GetProductWithDiscount(string productName);
        ProductPriceDto GetProductFinalPrice(string productName);

        public bool AgeValidation(DateTime dateBirth, string categoryName);

    }
}
