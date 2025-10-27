using TP_Final_APIs.Models.DTOs.Requests;
using TP_Final_APIs.Models.DTOs.Responses;

namespace TP_Final_APIs.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetCategories(int idUser);
        void CreateCategory(CreateAndUpdateCategoryDto newCategory);
        void DeleteCategory(int idCategory);
        void UpdateCategory(CreateAndUpdateCategoryDto updatedCategory, int idCategory);
        bool CheckIfCategoryExists(int idCategory);
    }
}
