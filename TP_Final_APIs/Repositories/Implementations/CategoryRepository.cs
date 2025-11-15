using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
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

        
        public IEnumerable<Category> GetCategories(int idUser)
        {
            return _context.Categories
                .Include(c => c.Products)  
                .Where(c => c.UserId == idUser)
                .ToList();
        }

        public bool CheckIfCategoryExists(int idCategory)
        {
            var categoryExistence = _context.Categories.Any(user => user.Id == idCategory);
            return categoryExistence;
        }
        public void UpdateCategory(Category updatedCategory)
        {
            var existingCategory = _context.Categories.Find(updatedCategory.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = updatedCategory.Name;
                _context.SaveChanges();
            }

        }

        public int? GetCategoryByName (string name, int userId)
        {
            if (userId == 0)
            {
                var response =_context.Categories.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
                return response?.Id;
            }
            else {
                var response = _context.Categories.FirstOrDefault(c => c.Name.ToLower() == name.ToLower() && c.UserId == userId);
                return response?.Id;
            }
        }
    }
}
