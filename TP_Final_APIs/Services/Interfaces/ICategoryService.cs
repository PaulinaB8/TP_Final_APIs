using TP_Final_APIs.Models.DTOs.Requests;
using TP_Final_APIs.Models.DTOs.Responses;

namespace TP_Final_APIs.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> getCategories(int idRestaurant);
        void createCategory(CreateAndUpdateCategoryDto newCategory);
        void deleteCategory(int idCategory);
        void updateCategory(CreateAndUpdateCategoryDto updatedCategory, int idCategory);
    }
}
