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
        public IEnumerable<ProductDto> GetProductsByCategory(int idCategory)
        {
            var products = _productRepository.GetProductsByCategory(idCategory);
            IEnumerable<ProductDto> miEnumerable = products.Select(p => new ProductDto()
            {
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                Discount = p.Discount,
                HappyHour = p.HappyHour,
                Favourite = p.Favourite,
                IdCategory = p.IdCategory,
            }).ToList();
            return miEnumerable;
        }



        public ProductDto GetProduct(int idProduct)
        {
            var product = _productRepository.GetProduct(idProduct);
            ProductDto productToReturn = new ProductDto()
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Discount = product.Discount,
                HappyHour = product.HappyHour,
                Favourite = product.Favourite,
                IdCategory = product.IdCategory,
            };
            return productToReturn;

        }



        public IEnumerable<ProductDto> GetFavouriteProducts()
        {
            var products = _productRepository.GetFavouriteProducts();
            IEnumerable<ProductDto> miEnumerable = products.Select(p => new ProductDto()
            {
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                Discount = p.Discount,
                HappyHour = p.HappyHour,
                Favourite = p.Favourite,
                IdCategory = p.IdCategory,
            }).ToList();
            return miEnumerable;
        }


        public IEnumerable<ProductDto> GetDiscountProducts()
        {
            var products = _productRepository.GetDiscountProducts();
            IEnumerable<ProductDto> miEnumerable = products.Select(p => new ProductDto()
            {
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                Discount = p.Discount,
                HappyHour = p.HappyHour,
                Favourite = p.Favourite,
                IdCategory = p.IdCategory,
            }).ToList();
            return miEnumerable;
        }



        public IEnumerable<ProductDto> GetHappyHourProducts()
        {
            var products = _productRepository.GetHappyHourProducts();
            IEnumerable<ProductDto> miEnumerable = products.Select(p => new ProductDto()
            {
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                Discount = p.Discount,
                HappyHour = p.HappyHour,
                Favourite = p.Favourite,
                IdCategory = p.IdCategory,
            }).ToList();
            return miEnumerable;
        }




        public void CreateProduct(CreateAndUpdateProductDto newProduct, int idCategory)
        {
            Product newProductToCreate = new Product()
            {
                Name = newProduct.Name,
                Price = newProduct.Price,
                Description = newProduct.Description,
                Discount = newProduct.Discount,
                HappyHour = newProduct.HappyHour,
                Favourite = newProduct.Favourite,
                IdCategory = newProduct.IdCategory,
            };
            _productRepository.CreateProduct(newProductToCreate);
        }


        public void DeleteProduct(int idProduct)
        {
            var product = _productRepository.GetProduct(idProduct);
            if (product != null)
            {
                _productRepository.DeleteProduct(idProduct);
            }
        }



        public void UpdateProduct(CreateAndUpdateProductDto updatedProduct, int idProduct)
        {
            var productExist = _productRepository.GetProduct(idProduct);
            if (productExist != null)
            {
                Product product = new Product()
                {
                    Name = updatedProduct.Name,
                    Price = updatedProduct.Price,
                    Description = updatedProduct.Description,
                    Discount = updatedProduct.Discount,
                    HappyHour = updatedProduct.HappyHour,
                    Favourite = updatedProduct.Favourite,
                    IdCategory = updatedProduct.IdCategory,
                };
                _productRepository.UpdateProduct(product, idProduct);
            }
        }



        public void ChangeDiscount(double discount, int idProduct)
        {
            var product = _productRepository.GetProduct(idProduct);
            if (product != null)
            {
                _productRepository.ChangeDiscount(discount, idProduct);
            }
        }



        public string ApplyHappyHour(int idProduct)
        {
            var product = _productRepository.GetProduct(idProduct);
            if (product != null)
            {
                string response = _productRepository.ApplyHappyHour(idProduct);
                return response;
            }
            else return "No se encontró el producto";

            
        }
    }
}
