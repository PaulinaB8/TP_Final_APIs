using Microsoft.EntityFrameworkCore;
using TP_Final_APIs.Data;
using TP_Final_APIs.Entities;
using TP_Final_APIs.Repositories.Interfaces;
using TP_Final_APIs.Services.Interfaces;

namespace TP_Final_APIs.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository

    {
        private readonly  TpFinalContexts  _context;
        public CategoryRepository(TpFinalContexts context)
        {
            _context = context;
        }

        public void CreateCategory(Category newCategory)
        {
            _context.Add(newCategory);
            _context.SaveChanges();
        }

        public void DeleteCategory(int idCategory)
        {
            var categoryToDelete = _context.Categories.FirstOrDefault(c => c.Id == idCategory);
            if (categoryToDelete != null)
            {
                _context.Remove(categoryToDelete);
            }
            _context.SaveChanges();
        }

        //public IEnumerable<Category> GetCategories(int idUser)
        //{
        //    return _context.Categories.Where(c => c.Id == idUser);

        //}
        public IEnumerable<Category> GetCategories(int idUser)
        {
            return _context.Categories
           .Include(c => c.Products)
           .ToList();
        }

        public bool CheckIfCategoryExists(int idCategory)
        {
            var categoryExistence = _context.Categories.Any(user => user.Id == idCategory);
            return categoryExistence;
        }
        public void UpdateCategory(Category updatedCategory, int idCategory)
        { 
                _context.Categories.Update(updatedCategory);
            _context.SaveChanges();

        }
    }
}
