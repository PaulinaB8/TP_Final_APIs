using Microsoft.EntityFrameworkCore;
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
        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public IEnumerable<ProductDto> GetProductsByCategory(string categoryName)
        {
            var idCategory = _categoryRepository.GetCategoryByName(categoryName);

            if (idCategory.HasValue)
            {
                var products = _productRepository.GetProductsByCategory(idCategory.Value);
                IEnumerable<ProductDto> miEnumerable = products.Select(p => new ProductDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    Discount = p.Discount,
                    HappyHour = p.HappyHour,
                    Favourite = p.Favourite
                }).ToList();
                return miEnumerable;
            }
            else return null;
        }


        public ProductDto? GetProduct(string productName)
        {
            int? idProduct = _productRepository.GetProductByName(productName);
            if (idProduct.HasValue)
            {
                var product = _productRepository.GetProduct(idProduct.Value);
                if (product == null)
                    return null;

                return new ProductDto
                {
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    Discount = product.Discount,
                    HappyHour = product.HappyHour,
                    Favourite = product.Favourite
                };
            }
            else return null;
            
        }



        public IEnumerable<FavouriteProductsDto> GetFavouriteProducts(string userName)
        {
            var products = _productRepository.GetFavouriteProducts(userName);
            IEnumerable<FavouriteProductsDto> miEnumerable = products.Select(p => new FavouriteProductsDto()
            {
                Name = p.Name,
                Price = p.Price,
                Description = p.Description
            }).ToList();
            return miEnumerable;
        }


        public IEnumerable<ProductsWithDiscountDto> GetDiscountProducts(string userName)
        {
            var products = _productRepository.GetDiscountProducts(userName);
            IEnumerable<ProductsWithDiscountDto> miEnumerable = products.Select(p => new ProductsWithDiscountDto()
            {
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                Discount = p.Discount
            }).ToList();
            return miEnumerable;
        }



        public IEnumerable<FavouriteProductsDto> GetHappyHourProducts(string userName)
        {
            var products = _productRepository.GetHappyHourProducts(userName);
            IEnumerable<FavouriteProductsDto> miEnumerable = products.Select(p => new FavouriteProductsDto()
            {
                Name = p.Name,
                Price = p.Price,
                Description = p.Description
                
            }).ToList();
            return miEnumerable;
        }




        public void CreateProduct(CreateProductDto newProduct, string categoryName)
        {
            var idCategory = _categoryRepository.GetCategoryByName(categoryName);

            if (idCategory.HasValue)
            {

                Product newProductToCreate = new Product()
                {
                    Name = newProduct.Name,
                    Price = newProduct.Price,
                    Description = newProduct.Description,
                    Discount = newProduct.Discount,
                    HappyHour = newProduct.HappyHour,
                    Favourite = newProduct.Favourite,
                    IdCategory = idCategory.Value,
                };
                _productRepository.CreateProduct(newProductToCreate);
            }
        }


        public void DeleteProduct(string productName)
        {
            var idProduct = _productRepository.GetProductByName(productName);
            Console.WriteLine(productName);
            if (idProduct.HasValue)
            {
                _productRepository.DeleteProduct(idProduct.Value);
            }
        }



        public void UpdateProduct(UpdateProductDto updatedProduct, string productName)
        {
            var idProduct = _productRepository.GetProductByName(productName);
            if (idProduct.HasValue)
            {
                var productExist = _productRepository.GetProduct(idProduct.Value);
                if (productExist != null)
                {
                    
                    productExist.Name = updatedProduct.Name;
                    productExist.Price = updatedProduct.Price;
                    productExist.Description = updatedProduct.Description;
                    productExist.Discount = updatedProduct.Discount;
                    productExist.HappyHour = updatedProduct.HappyHour;
                    productExist.Favourite = updatedProduct.Favourite;
                    productExist.IdCategory = updatedProduct.IdCategory;

                    _productRepository.UpdateProduct(productExist);
                }
               
            }
        }


        public void ChangeDiscount(double discount, string productName)
        {
            var idProduct = _productRepository.GetProductByName(productName);
            if (idProduct.HasValue)
            {
                var product = _productRepository.GetProduct(idProduct.Value);
                if (product != null)
                {
                    _productRepository.ChangeDiscount(discount, idProduct.Value);
                }
            }
            
        }



        public string ApplyHappyHour(string productName)
        {
            var idProduct = _productRepository.GetProductByName(productName);
            if (idProduct.HasValue)
            {
                var product = _productRepository.GetProduct(idProduct.Value);
                if (product != null)
                {
                    string response = _productRepository.ApplyHappyHour(idProduct.Value);
                    return response;
                }
                else return "No se encontró el producto";
            }
            else return "No se encontró el producto";
        }


        public ProductWithDiscountDto GetProductWithDiscount(string productName)
        {
            
            var productId = _productRepository.GetProductByName(productName);

            if (!productId.HasValue)
            {
                return null;
            }

            var product = _productRepository.GetProduct(productId.Value);

            if (product == null)
            {
                return null;
            }

             double finalPrice = product.Discount > 0
                ? product.Price - (product.Price * product.Discount / 100)
                : product.Price;

            return new ProductWithDiscountDto
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Discount = product.Discount,
                HappyHour = product.HappyHour,
                Favourite = product.Favourite,
                FinalPrice = finalPrice
            };
        }
        public ProductPriceDto GetProductFinalPrice(string productName)
        {
            // Buscar el producto por nombre
            var productId = _productRepository.GetProductByName(productName);

            if (!productId.HasValue)
            {
                return null;
            }

            var product = _productRepository.GetProduct(productId.Value);

            if (product == null)
            {
                return null;
            }

            // Calcular el precio final con descuento
            double finalPrice = product.Discount > 0
                ? product.Price - (product.Price * product.Discount / 100)
                : product.Price;

            return new ProductPriceDto
            {
                Name = product.Name,
                FinalPrice = finalPrice
            };

        }

    }
}
