using TP_Final_APIs.Entities;

namespace TP_Final_APIs.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories(int idUser);
        
        void UpdateCategory(Category updatedCategory);
        void DeleteCategory(int idCategory);
        void CreateCategory(Category newCategory); 
        bool CheckIfCategoryExists(int idCategory);

        public int? GetCategoryByName(string name, int userId);

    }
}
