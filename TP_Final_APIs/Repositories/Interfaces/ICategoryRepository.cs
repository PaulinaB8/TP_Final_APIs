using TP_Final_APIs.Entities;

namespace TP_Final_APIs.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories(int idUser);
        
        void UpdateCategory(Category updatedCategory, int idCategory);
        void DeleteCategory(int idCategory);
        void CreateCategory(Category newCategory, int userId); 
        bool CheckIfCategoryExists(int idCategory);

    }
}
