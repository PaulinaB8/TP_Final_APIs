using TP_Final_APIs.Models.DTOs.Requests;
using TP_Final_APIs.Models.DTOs.Responses;

namespace TP_Final_APIs.Services.Interfaces
{
    public interface IProductService
    {
        public IEnumerable<ProductDto> getProductsByCategory(int idCategory);
        public ProductDto getProduct(int idProduct);
        public IEnumerable<ProductDto> getFavouriteProducts();
        public IEnumerable<ProductDto> getDiscountProducts();
        public IEnumerable<ProductDto> getHappyHourProducts();

        public void createProduct(CreateAndUpdateProductDto newProduct, int idCategory);
        public void deleteProduct(int idProduct);
        public void updateProduct(CreateAndUpdateProductDto updatedProduct, int idProduct);
        public void changeDiscount(double discount);
        public string applyHappyHour(int idProduct);
    }
}
