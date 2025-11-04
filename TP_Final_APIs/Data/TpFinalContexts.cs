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
    //    User luis = new User() //cuando crea la base de datos ya genera un usuario llamado Luis
    //    {
    //        Id = 1,
    //        Name = "Luis",
    //        Password = "lamismadesiempre",
    //        Mail = "luis@gmail.com",
    //        Status = true,
    //        Phone = "34112345",
    //        CategoryId = null,

        //    };

        //    modelBuilder.Entity<User>().HasData(
        //            luis);

        //    Category entradas = new Category() //cuando crea la base de datos ya genera un usuario llamado Luis
        //    {
        //        Id = 1,
        //        Name = "Entradas",


        //    };


        //    modelBuilder.Entity<Category>().HasData(
        //                entradas);

        //    Product rabas = new Product() //cuando crea la base de datos ya genera un usuario llamado Luis
        //    {
        //        Id = 1,
        //        Name = "Rabas",
        //        Price = 1500,
        //        Description = "Rabas con limón",
        //        HappyHour = false,
        //        Favourite = true,
        //        IdCategory = 1

        //    };

        //    modelBuilder.Entity<Product>()
        //        .HasOne(p => p.Category)
        //        .WithMany(c => c.Products)
        //        .HasForeignKey(p => p.IdCategory)
        //        .OnDelete(DeleteBehavior.Restrict);


        //    base.OnModelCreating(modelBuilder);
        //}

        base.OnModelCreating(modelBuilder);

        // Relación Category-Product (si no está por convención)
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.IdCategory)
            .OnDelete(DeleteBehavior.Restrict);

        var luis = new User
        {
            Id = 1,
            Name = "Luis",
            Password = "lamismadesiempre",
            Mail = "luis@gmail.com",
            Status = true,
            Phone = "34112345",
            CategoryId = null
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
    }
}


