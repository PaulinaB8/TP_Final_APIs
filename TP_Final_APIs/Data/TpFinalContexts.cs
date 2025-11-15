
using Microsoft.EntityFrameworkCore;
using TP_Final_APIs.Entities;

namespace TP_Final_APIs.Data;

public class TpFinalContexts : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public TpFinalContexts(DbContextOptions<TpFinalContexts> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

       
        modelBuilder.Entity<User>()
            .HasMany(u => u.Categories)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)  
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.IdCategory)
            .OnDelete(DeleteBehavior.Restrict);

        

        
        var viaPizza = new User
        {
            Id = 1,
            Name = "Via Pizza",
            Password = "viapizzapassword",
            Mail = "viapizza@gmail.com",
            Status = true,
            Phone = "34112345"
        };

        
        var entradas = new Category
        {
            Id = 1,
            Name = "Entradas",
            UserId = 1  
        };

        var principales = new Category
        {
            Id = 2,
            Name = "Principales",
            UserId = 1
        };

        var bebidas = new Category
        {
            Id = 3,
            Name = "Bebidas",
            UserId = 1
        };

        
        var rabas = new Product
        {
            Id = 1,
            Name = "Rabas",
            Price = 1500,
            Description = "Rabas con limón",
            Discount = 0,
            HappyHour = false,
            Favourite = true,
            IdCategory = 1
        };

        var milanesa = new Product
        {
            Id = 2,
            Name = "Milanesa Napolitana",
            Price = 3500,
            Description = "Milanesa con jamón y queso",
            Discount = 10,
            HappyHour = false,
            Favourite = true,
            IdCategory = 2
        };

        var cocaCola = new Product
        {
            Id = 3,
            Name = "Coca Cola",
            Price = 800,
            Description = "Coca Cola 500ml",
            Discount = 0,
            HappyHour = true,
            Favourite = false,
            IdCategory = 3
        };

        
        modelBuilder.Entity<User>().HasData(viaPizza);
        modelBuilder.Entity<Category>().HasData(entradas, principales, bebidas);
        modelBuilder.Entity<Product>().HasData(rabas, milanesa, cocaCola);
    }
}


