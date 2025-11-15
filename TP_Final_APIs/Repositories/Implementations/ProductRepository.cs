using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Xml.Linq;
using TP_Final_APIs.Data;
using TP_Final_APIs.Entities;
using TP_Final_APIs.Repositories.Interfaces;

namespace TP_Final_APIs.Repositories.Implementations;

public class ProductRepository : IProductRepository
{
    private readonly TpFinalContexts _context;

    public ProductRepository(TpFinalContexts context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IEnumerable<Product>? GetProductsByCategory(int idCategory, int userId)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == idCategory && c.UserId == userId);
        if(category is not null)
        {
            return _context.Products.Where(x => x.IdCategory == idCategory).ToList();
        }
        return null;
    }
    public Product? GetProduct(int idProduct)
    {
        return _context.Products.FirstOrDefault(x => x.Id == idProduct);

    }
    //public IEnumerable<Product> GetFavouriteProducts(string userName)
    //{
    //    return _context.Products.Where(x => x.Favourite == true &&
    //    x.Category.User.Name == userName).ToList();
    //}

    public IEnumerable<Product> GetFavouriteProducts(string userName)
    {
        return _context.Products
            .Include(x => x.Category)
                .ThenInclude(c => c.User)
            .Where(x => x.Favourite == true && x.Category.User.Name == userName)
            .ToList();
    }
    //public IEnumerable<Product> GetDiscountProducts(string userName)
    //{
    //    return _context.Products.Where(x => x.Discount > 0 && 
    //    x.Category.User.Name == userName).ToList();
    //}

    public IEnumerable<Product> GetDiscountProducts(string userName)
    {
        return _context.Products
            .Include(x => x.Category)
                .ThenInclude(c => c.User)
            .Where(x => x.Discount > 0 && x.Category.User.Name == userName)
            .ToList();
    }

    //public IEnumerable<Product> GetHappyHourProducts(string userName)
    //{
    //    return _context.Products.Where(x => x.HappyHour == true && 
    //    x.Category.User.Name == userName).ToList();
    //}

    public IEnumerable<Product> GetHappyHourProducts(string userName)
    {
        return _context.Products
            .Include(x => x.Category)
                .ThenInclude(c => c.User)
            .Where(x => x.HappyHour == true && x.Category.User.Name == userName)
            .ToList();
    }

    public void CreateProduct(Product newProduct)
    {
        _context.Products.Add(newProduct);
        _context.SaveChanges();
    }
    public void DeleteProduct(int idProduct)
    {
        _context.Products.Remove(GetProduct(idProduct));
        _context.SaveChanges();
    }


    public void UpdateProduct(Product updatedProduct)
    {
        _context.SaveChanges();
    }



    public void ChangeDiscount(double discount, int idProduct)
    {
        var productToChange = GetProduct(idProduct);
        productToChange.Discount = discount;
        _context.SaveChanges();
    }

    public string ApplyHappyHour(int idProduct)
    {
        var productToChange = GetProduct(idProduct);
        if (productToChange.HappyHour == true)
        {
            productToChange.HappyHour = false;
            _context.SaveChanges();

            return "El Happy Hour se desactivó";
        }
        else
        {
            productToChange.HappyHour = true;
            _context.SaveChanges();
            return "El Happy Hour se activó ";
        }
    }

    public int? GetProductByName(string productName)
    {
        var response = _context.Products.FirstOrDefault(c => c.Name.ToLower() == productName.ToLower());
        return response?.Id;
    }


    //public int? GetProductByName(string productName, int userId)
    //{
    //    var response = _context.Products.FirstOrDefault(c => c.Name.ToLower() == productName.ToLower());
    //    if (response != null)
    //    {
    //        var validitionCategory = _context.Categories.FirstOrDefault(c => c.Id == response.IdCategory && c.UserId == userId);
    //        if (validitionCategory != null)
    //        {
    //            return response?.Id;
    //        }

    //    }
    //    return null;
    //}
}
