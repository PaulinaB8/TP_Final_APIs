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
        public void createCategory(CreateAndUpdateCategoryDto newCategory)
        {
            var category = new Category
            {
                Name = newCategory.Name,
                Products = newCategory.Products
            };

            _categoryRepository.createCategory(category);
        }

        public void deleteCategory(int idCategory)
        {
            _categoryRepository.deleteCategory(idCategory);
        }

        public IEnumerable<CategoryDto> getCategories(int idUser)
        {

            
        }

        public void updateCategory(CreateAndUpdateCategoryDto updatedCategory, int idCategory)
        {
            Category updatedCategoryDto = new Category()
            {
                Name = updatedCategory.Name,
                Products = updatedCategory.Products

                
            };

            _categoryRepository.updateCategory(updatedCategoryDto, idCategory);
        }
    }
}
