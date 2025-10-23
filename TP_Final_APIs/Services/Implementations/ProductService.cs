using System.ComponentModel.DataAnnotations;
using TP_Final_APIs.Entities;
using TP_Final_APIs.Models.DTOs.Requests;
using TP_Final_APIs.Models.DTOs.Responses;
using TP_Final_APIs.Repositories.Interfaces;
using TP_Final_APIs.Services.Interfaces;

namespace TP_Final_APIs.Services.Implementations
{
    public class ProductService :IProductService
    {
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        private readonly IProductRepository _productRepository;
        public IEnumerable<ProductDto> getProductsByCategory(int idCategory)
        {
            var products = _productRepository.getProductsByCategory(idCategory);
            IEnumerable<ProductDto> miEnumerable = products.Select(p => new ProductDto()
            {
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                Discount = p.Discount,
                HappyHour = p.HappyHour,
                Favourite = p.Favourite,
                IdCaterogies = p.IdCaterogies,
            }).ToList();
            return miEnumerable;
        }
        public ProductDto getProduct(int idProduct)
        {
            var product = _productRepository.getProduct(idProduct);
            ProductDto productToReturn = new ProductDto()
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Discount = product.Discount,
                HappyHour = product.HappyHour,
                Favourite = product.Favourite,
                IdCaterogies = product.IdCaterogies,
            };
            return productToReturn;

        }
        public IEnumerable<ProductDto> getFavouriteProducts()
        {
            var products = _productRepository.getFavouriteProducts();
            IEnumerable<ProductDto> miEnumerable = products.Select(p => new ProductDto()
            {
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                Discount = p.Discount,
                HappyHour = p.HappyHour,
                Favourite = p.Favourite,
                IdCaterogies = p.IdCaterogies,
            }).ToList();
            return miEnumerable;
        }
        public IEnumerable<ProductDto> getDiscountProducts()
        {
            var products = _productRepository.getDiscountProducts();
            IEnumerable<ProductDto> miEnumerable = products.Select(p => new ProductDto()
            {
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                Discount = p.Discount,
                HappyHour = p.HappyHour,
                Favourite = p.Favourite,
                IdCaterogies = p.IdCaterogies,
            }).ToList();
            return miEnumerable;
        }
        public IEnumerable<ProductDto> getHappyHourProducts()
        {
            var products = _productRepository.getHappyHourProducts();
            IEnumerable<ProductDto> miEnumerable = products.Select(p => new ProductDto()
            {
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                Discount = p.Discount,
                HappyHour = p.HappyHour,
                Favourite = p.Favourite,
                IdCaterogies = p.IdCaterogies,
            }).ToList();
            return miEnumerable;
        }

        public void createProduct(CreateAndUpdateProductDto newProduct, int idCategory)
        {
            Product newProductToCreate = new Product()
            {
                Name = newProduct.Name,
                Price = newProduct.Price,
                Description = newProduct.Description,
                Discount = newProduct.Discount,
                HappyHour = newProduct.HappyHour,
                Favourite = newProduct.Favourite,
                IdCaterogies = newProduct.IdCaterogies,
            };
            _productRepository.createProduct(newProductToCreate);
        }
        public void deleteProduct(int idProduct)
        {
            var product = _productRepository.getProduct(idProduct);
            if (product != null)
            {
                _productRepository.deleteProduct(idProduct);
            }
        }
        public void updateProduct(CreateAndUpdateProductDto updatedProduct, int idProduct)
        {
            Product product = new Product()
            {
                Name = updatedProduct.Name,
                Price = updatedProduct.Price,
                Description = updatedProduct.Description,
                Discount = updatedProduct.Discount,
                HappyHour = updatedProduct.HappyHour,
                Favourite = updatedProduct.Favourite,
                IdCaterogies = updatedProduct.IdCaterogies,
            };
            _productRepository.updateProduct(product, idProduct);
        }
        public void changeDiscount(double discount, int idProduct)
        {
            _productRepository.changeDiscount(discount,idProduct);
        }
        public string applyHappyHour(int idProduct)
        {
            string response =_productRepository.applyHappyHour(idProduct);
            return response;
        }
    }
}
