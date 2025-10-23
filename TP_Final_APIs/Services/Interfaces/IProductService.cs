using TP_Final_APIs.Models.DTOs.Requests;
using TP_Final_APIs.Models.DTOs.Responses;

namespace TP_Final_APIs.Services.Interfaces
{
    public interface IProductService
    {
         IEnumerable<ProductDto> getProductsByCategory(int idCategory);
         ProductDto getProduct(int idProduct);
         IEnumerable<ProductDto> getFavouriteProducts();
         IEnumerable<ProductDto> getDiscountProducts();
         IEnumerable<ProductDto> getHappyHourProducts();

         void createProduct(CreateAndUpdateProductDto newProduct, int idCategory);
         void deleteProduct(int idProduct);
         void updateProduct(CreateAndUpdateProductDto updatedProduct, int idProduct);
         void changeDiscount(double discount, int idProduct);
         string applyHappyHour(int idProduct);
    }
}
