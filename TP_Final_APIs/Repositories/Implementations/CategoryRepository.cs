using TP_Final_APIs.Entities;
using TP_Final_APIs.Repositories.Interfaces;
using TP_Final_APIs.Services.Interfaces;

namespace TP_Final_APIs.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository

    {
        List<Category> _context = new List<Category>();
        public void createCategory(Category newCategory)
        {
            _context.Add(newCategory);
        }

        public void deleteCategory(int idCategory)
        {
            var categoryToDelete = _context.FirstOrDefault(c => c.Id == idCategory);
            if (categoryToDelete != null)
            {
                _context.Remove(categoryToDelete);
            }
        }

        public IEnumerable<Category> getCategory(int idUser)
        {
            return _context.Where(c => c.Id == idUser);
        }

        public void updateCategory(Category updatedCategory, int idCategory)
        {
            

        }
    }
}
