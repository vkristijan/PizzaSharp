using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PizzaSharp.Models;

namespace PizzaSharp
{
    class PizzaDbContext : System.Data.Entity.DbContext
    {
        public PizzaDbContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Product> Products { get; set; }
        


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // PIZZA
            modelBuilder.Entity<Pizza>().HasMany(s => s.Ingredients);
            modelBuilder.Entity<Pizza>().HasOptional(s => s.Reviews);
            modelBuilder.Entity<Pizza>().HasOptional(s => s.Comments);

            // COMMENT
            modelBuilder.Entity<Comment>().HasKey(s => s.Pizza);
            modelBuilder.Entity<Comment>().HasKey(s => s.User);
            modelBuilder.Entity<Comment>().Property(s => s.Text).IsRequired();

            // REVIEW 
            modelBuilder.Entity<Review>().HasKey(s => s.Pizza);
            modelBuilder.Entity<Review>().HasKey(s => s.User);
            modelBuilder.Entity<Review>().Property(s => s.Grade).IsRequired();

            // INGREDIENT
            modelBuilder.Entity<Ingredient>().HasKey(s => s.Name);
            modelBuilder.Entity<Ingredient>().Property(s => s.PhotoName).IsOptional();
            modelBuilder.Entity<Ingredient>().Property(s => s.Price).IsRequired();

            // ORDER
            modelBuilder.Entity<Order>().HasKey(s => s.User);
            modelBuilder.Entity<Order>().HasKey(s => s.DateCreated);
            modelBuilder.Entity<Order>().HasMany(s => s.Items);
            modelBuilder.Entity<Order>().Property(s => s.DeliveryAddress).IsRequired();
            modelBuilder.Entity<Order>().Property(s => s.Delivery).IsOptional();            
            modelBuilder.Entity<Order>().Property(s => s.DeliveryDate).IsOptional();
            modelBuilder.Entity<Order>().Property(s => s.DeliveryMessage).IsOptional();

            // ITEM
            modelBuilder.Entity<Item>().HasKey(s => s.Product);
            modelBuilder.Entity<Item>().Property(s => s.Size).IsRequired();
            modelBuilder.Entity<Item>().Property(s => s.Amount).IsRequired();

            // DRINK

            // PRODUCT
            modelBuilder.Entity<Product>().HasKey(s => s.ProductId);
            modelBuilder.Entity<Product>().Property(s => s.PriceSmall).IsRequired();
            modelBuilder.Entity<Product>().Property(s => s.PriceMedium).IsRequired();
            modelBuilder.Entity<Product>().Property(s => s.PriceBig).IsRequired();
            modelBuilder.Entity<Product>().Property(s => s.PhotoName).IsOptional();
        }

    }
}
