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
       
        public CategoryService(ICategoryRepository categoryRepository, IUserRepository userRepository)
        {
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
        } 
        
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        public void CreateCategory(int idUser, CreateCategoryDto newCategory)
        {
            var category = new Category
            {
                Name = newCategory.Name,
                UserId = idUser
            };

            _categoryRepository.CreateCategory(category);

            
        }


        public void DeleteCategory(string categoryName)
        {
            var idCategory = _categoryRepository.GetCategoryByName(categoryName);
            if (idCategory.HasValue)
            {
                _categoryRepository.DeleteCategory(idCategory.Value);
            }
        }

        public IEnumerable<CategoryDto>? GetCategories(string userName, DateTime dateBirth)
        {
            var idUser = _userRepository.GetUserByName(userName);
            if (idUser.HasValue)
            {
                var category = _categoryRepository.GetCategories(idUser.Value);

                int edad = DateTime.Today.Year - dateBirth.Year;

                if (dateBirth.Date > DateTime.Today.AddYears(-edad))
                {
                    edad--;
                }
                var categoryList = category.ToList();

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
            return null;
        }





        public void UpdateCategory(UpdateCategoryDto updatedCategory, string categoryName)
        {
            var idCategory = _categoryRepository.GetCategoryByName(categoryName);
            if (idCategory.HasValue)
            {
                var categoryToUpdate = new Category
                {
                    Id = idCategory.Value,
                    Name = updatedCategory.Name,
             };


                _categoryRepository.UpdateCategory(categoryToUpdate, idCategory.Value);
            }
        }


        public bool CheckIfCategoryExists(int idUser)
        {
            var response = _categoryRepository.CheckIfCategoryExists(idUser);
            return response;
        }
    }
}
