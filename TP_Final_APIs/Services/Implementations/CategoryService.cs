using TP_Final_APIs.Models.DTOs.Requests;
using TP_Final_APIs.Models.DTOs.Responses;
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
            throw new NotImplementedException();
        }

        public void deleteCategory(int idCategory)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryDto> getMenu(int idRestaurant)
        {
            throw new NotImplementedException();
        }

        public void updateCategory(CreateAndUpdateCategoryDto updatedCategory, int idCategory)
        {
            throw new NotImplementedException();
        }
    }
}
