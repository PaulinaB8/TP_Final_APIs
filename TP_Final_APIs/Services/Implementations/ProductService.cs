using Humanizer;
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
        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
        }
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        public IEnumerable<ProductDto>? GetProductsByCategory(string categoryName, string userName)
        {
            
            var idUser = _userRepository.GetUserByName(userName);
            if (!idUser.HasValue)
                return null;

            
            int? categoryId = _categoryRepository.GetCategoryByName(categoryName, idUser.Value);
            if (categoryId == null)
                return null;

            var products = _productRepository.GetProductsByCategory(categoryId.Value, idUser.Value);

            
            var miEnumerable = products.Select(p => new ProductDto
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

        
        

        public ProductDto? GetProduct(string productName, string userName)
        {
  
            var idUser = _userRepository.GetUserByName(userName);
            if (!idUser.HasValue)
                return null;

            int userId = idUser.Value;

            
            var productId = _productRepository.GetProductByName(productName);
            if (!productId.HasValue)
                return null;

            
            Product? product = _productRepository.GetProduct(productId.Value);
            if (product == null)
                return null;

            var category = _categoryRepository.GetCategory(product.IdCategory);


            if (category.UserId != userId)
            {
                return null;
            }

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




        public string? CreateProduct(CreateProductDto newProduct, string categoryName, int userId)
        {
            var validationProduct = CheckIfProductExists(newProduct.Name, userId);
            if(validationProduct)
            {
                return null;
            }
            var idCategory = _categoryRepository.GetCategoryByName(categoryName, userId);

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
                return "Creado existosamente";
            }
            return "El usuario no tiene la categoría";
        }


        public bool DeleteProduct(string productName, int userId)
        {
            var idProduct = _productRepository.GetProductByName(productName, userId);
            if (!idProduct.HasValue)
            {
                return false; 
            }

            _productRepository.DeleteProduct(idProduct.Value);
            return true; 
        }


        public string UpdateProduct(UpdateProductDto updatedProduct, string productName, int userId)
        {
            var idProduct = _productRepository.GetProductByName(productName, userId);
            if (!idProduct.HasValue)
            {
                return "El producto no existe";
            }

            var productExist = _productRepository.GetProduct(idProduct.Value);
            if (productExist == null)
            {
                return "El producto no existe";
            }

            
            if (productExist.Name.Trim().ToLower() != updatedProduct.Name.Trim().ToLower())
            {
                var validationProduct = CheckIfProductExists(updatedProduct.Name, userId);
                if (validationProduct)
                {
                    return "El nombre del producto al que se quiere actualizar ya existe";
                }
            }

            productExist.Name = updatedProduct.Name;
            productExist.Price = updatedProduct.Price;
            productExist.Description = updatedProduct.Description;
            productExist.Discount = updatedProduct.Discount;
            productExist.HappyHour = updatedProduct.HappyHour;
            productExist.Favourite = updatedProduct.Favourite;
            

            _productRepository.UpdateProduct(productExist);

            return "Actualización exitosa";
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

        public bool AgeValidation (DateTime dateBirth, string categoryName)
        {
            int edad = DateTime.Today.Year - dateBirth.Year;

            if (dateBirth.Date > DateTime.Today.AddYears(-edad))
            {
                edad--;
            }

            if (edad < 18 && categoryName.Contains("alcoh", StringComparison.OrdinalIgnoreCase))
            {
                return false;

            }
            return true;
        }

        public bool AgeValidation(DateTime dateBirth)
        {
            int edad = DateTime.Today.Year - dateBirth.Year;
            if (dateBirth.Date > DateTime.Today.AddYears(-edad))
            {
                edad--;
            }
            if (edad < 18)
            {
                return false;
            }
            return true;
        }

        public bool CheckIfProductExists(string productName, int userId)
        {
            return _productRepository.CheckIfProductExists(productName, userId);
        }

    }

    
}
