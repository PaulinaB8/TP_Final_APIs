using System.Xml.Linq;
using TP_Final_APIs.Entities;
using TP_Final_APIs.Models.DTOs.Requests;
using TP_Final_APIs.Models.DTOs.Responses;
using TP_Final_APIs.Repositories.Implementations;
using TP_Final_APIs.Repositories.Interfaces;
using TP_Final_APIs.Services.Interfaces;

namespace TP_Final_APIs.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void CreateCategory(int idUser, CreateCategoryDto newCategory)
        {
            var category = new Category
            {
                Name = newCategory.Name,
                UserId = idUser
            };

            _categoryRepository.CreateCategory(category);

            
        }


        public void DeleteCategory(int idCategory)
        {
            _categoryRepository.DeleteCategory(idCategory);
        }

        public IEnumerable<CategoryDto> GetCategories(int idUser, DateTime dateBirth)
        {
            var category = _categoryRepository.GetCategories(idUser);

            int edad = DateTime.Today.Year - dateBirth.Year;

            if (dateBirth.Date > DateTime.Today.AddYears(-edad))
            {
                edad--;
            }

            if (edad < 18)
            {
                category = category.
                    Where(c => !c.Name.Equals("Bebidas alcohólicas", StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            var categoryToReturn = category.Select(c => new CategoryDto
            {
                Name = c.Name,

                Products = c.Products.Select(p => new ProductListDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description
                }).ToList()
            }).ToList();
            return categoryToReturn;

            
        }


public void UpdateCategory(UpdateCategoryDto updatedCategory, int idCategory)
        {
            var categoryToUpdate = new Category
            {
                Id = idCategory,                  
                Name = updatedCategory.Name,
                Products = updatedCategory.Products
            .Select(p => new Product
            {
                
                Name = p.Name,
                Price = p.Price,
                Description = p.Description
            })
            .ToList()
            };


            _categoryRepository.UpdateCategory(categoryToUpdate, idCategory);
        }


        public bool CheckIfCategoryExists(int idUser)
        {
            var response = _categoryRepository.CheckIfCategoryExists(idUser);
            return response;
        }
    }
}
