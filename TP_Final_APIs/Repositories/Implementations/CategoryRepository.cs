using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;
using System.Text;
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

        //public int? GetCategoryByName (string name, int userId = 0)
        //{
        //    if (userId == 0)
        //    {
        //        var response =_context.Categories.FirstOrDefault(c => c.Name.Trim().ToLower() == name.Trim().ToLower());
        //        return response?.Id;
        //    }
        //    else {
        //        var response = _context.Categories.FirstOrDefault(c => c.Name.Trim().ToLower() == name.Trim().ToLower() && c.UserId == userId);
        //        return response?.Id;
        //    }
        //}
        public int? GetCategoryByName(string name, int userId = 0)
        {
            if (userId == 0)
            {
                var response = _context.Categories
                    .AsEnumerable() // Trae a memoria para poder usar RemoveAccents
                    .FirstOrDefault(c => RemoveAccents(c.Name.Trim()).Equals(RemoveAccents(name.Trim()), StringComparison.OrdinalIgnoreCase));
                return response?.Id;
            }
            else
            {
                var response = _context.Categories
                    .Where(c => c.UserId == userId) // Filtra por userId en la BD primero
                    .AsEnumerable() // Luego trae a memoria
                    .FirstOrDefault(c => RemoveAccents(c.Name.Trim()).Equals(RemoveAccents(name.Trim()), StringComparison.OrdinalIgnoreCase));
                return response?.Id;
            }
        }

        public string RemoveAccents(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public Category? GetCategory(int idCategory)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == idCategory);
        }
    }
}
