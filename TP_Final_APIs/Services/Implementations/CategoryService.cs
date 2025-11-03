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
        public void CreateCategory(CreateAndUpdateCategoryDto newCategory)
        {
            var category = new Category
            {
                Name = newCategory.Name,
                Products = newCategory.ProductId
            };

            _categoryRepository.CreateCategory(category);
        }

        public void DeleteCategory(int idCategory)
        {
            _categoryRepository.DeleteCategory(idCategory);
        }

        public IEnumerable<CategoryDto> GetCategories(int idUser)
        {
            var category = _categoryRepository.GetCategories(idUser);

            IEnumerable<CategoryDto> categoryToReturn = category.Select(c => new CategoryDto()
            {
                Name = c.Name,
                ProductId = c.Products,
            }).ToList();
            return categoryToReturn; 
        }

        public void UpdateCategory(CreateAndUpdateCategoryDto updatedCategory, int idCategory)
        {
            Category updatedCategoryDto = new Category()
            {
                Name = updatedCategory.Name,
                Products = updatedCategory.ProductId

                
            };

            _categoryRepository.UpdateCategory(updatedCategoryDto, idCategory);
        }

        public bool CheckIfCategoryExists(int idUser)
        {
            var response = _categoryRepository.CheckIfCategoryExists(idUser);
            return response;
        }
    }
}
