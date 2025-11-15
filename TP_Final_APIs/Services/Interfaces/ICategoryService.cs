using TP_Final_APIs.Models.DTOs.Requests;
using TP_Final_APIs.Models.DTOs.Responses;

namespace TP_Final_APIs.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetCategories(string userName, DateTime dateBirth);
        void CreateCategory(int userId, CreateCategoryDto newCategory);
        void DeleteCategory(string categoryName, int userId);
        bool UpdateCategory(UpdateCategoryDto updatedCategory, string categoryName, int userId);
        bool CheckIfCategoryExists(int idCategory);
    }
}
