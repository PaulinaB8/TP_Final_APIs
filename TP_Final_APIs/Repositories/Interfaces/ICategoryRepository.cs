using TP_Final_APIs.Entities;

namespace TP_Final_APIs.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> getMenu(int idRestaurant);
        void updateCategory(Category updatedCategory, int idCategory);
        void deleteCategory(int idCategory);
        void createCategory(Category newCategory);

    }
}
