using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
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

    public IEnumerable<Product> GetProductsByCategory(int idCategory)
    {
        return _context.Products.Where(x => x.IdCategory == idCategory).ToList();
    }
    public Product? GetProduct(int idProduct)
    {
        return _context.Products.FirstOrDefault(x => x.Id == idProduct);
        
    }
    public IEnumerable<Product> GetFavouriteProducts()
    {
        return _context.Products.Where(x => x.Favourite == true).ToList();
    }
    public IEnumerable<Product> GetDiscountProducts()
    {
        return _context.Products.Where(x => x.Discount > 0).ToList();
    }


    public IEnumerable<Product> GetHappyHourProducts()
    {
        return _context.Products.Where(x => x.HappyHour == true).ToList();
    }

    public void CreateProduct(Product newProduct)
    {
        _context.Add(newProduct);
        _context.SaveChanges();
    }
    public void DeleteProduct(int idProduct)
    {
        _context.Remove(GetProduct(idProduct));
        _context.SaveChanges();
    }


    public void UpdateProduct(Product updatedProduct, int idProduct)
    {
        _context.Products.Update(updatedProduct);
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
            
            return "El Happy Hour se desactivó";
        }
        else
        {
            productToChange.HappyHour = true;
            return "El Happy Hour se activó ";
        }
    }
}
