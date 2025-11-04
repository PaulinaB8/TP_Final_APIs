using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        // Relación Many-to-Many User-Category
        modelBuilder.Entity<User>()
            .HasMany(u => u.Categories)
            .WithMany(c => c.Users)
            .UsingEntity(j => j.ToTable("UserCategories")); // Opcional: nombre de tabla intermedia

        // Relación Category-Product
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.IdCategory)
            .OnDelete(DeleteBehavior.Restrict);

        // Seed data - SIN incluir las propiedades de navegación
        var luis = new User
        {
            Id = 1,
            Name = "Luis",
            Password = "lamismadesiempre",
            Mail = "luis@gmail.com",
            Status = true,
            Phone = "34112345"
            // NO incluyas Categories aquí
        };

        var entradas = new Category
        {
            Id = 1,
            Name = "Entradas"
        };

        var rabas = new Product
        {
            Id = 1,
            Name = "Rabas",
            Price = 1500,
            Description = "Rabas con limón",
            HappyHour = false,
            Favourite = true,
            IdCategory = 1
        };

        modelBuilder.Entity<User>().HasData(luis);
        modelBuilder.Entity<Category>().HasData(entradas);
        modelBuilder.Entity<Product>().HasData(rabas);

        // Si quieres asociar Luis con la categoría Entradas en el seed:
        modelBuilder.Entity<User>()
            .HasMany(u => u.Categories)
            .WithMany(c => c.Users)
            .UsingEntity(j => j.HasData(
                new { UsersId = 1, CategoriesId = 1 } // Luis asociado a Entradas
            ));
    }
}



