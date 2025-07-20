using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online_Restaurant_Management.Models;

namespace Online_Restaurant_Management.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ProductIngredient> ProductIngredients { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //define composite key and relationships for ProductIngredient
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Catagory)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CatagoryId);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);
            modelBuilder.Entity<ProductIngredient>()
                .HasKey(pi => new { pi.ProductId, pi.IngredientId });

            //seed data  
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Appetizer" },
                new Category { CategoryId = 2, Name = "Entree" },
                new Category { CategoryId = 3, Name = "Side Dish" },
                new Category { CategoryId = 4, Name = "Dessert" },
                new Category { CategoryId = 5, Name = "Beverage" }
                );
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientId = 1, Name = "Beef" },
                new Ingredient { IngredientId = 2, Name = "Chicken" },
                new Ingredient { IngredientId = 3, Name = "fish" },
                new Ingredient { IngredientId = 4, Name = "tortilla" },
                new Ingredient { IngredientId = 5, Name = "lettuce" },
                new Ingredient { IngredientId = 6, Name = "tomato" }
                );
            modelBuilder.Entity<Product>().HasData(
                //Add mexican restaurant food entries here
                new Product
                {
                    ProductId = 1,
                    Name = "beef taco",
                    Description = "a delicious beef taco",
                    Price = 2.5m,
                    Stock = 100,
                    CatagoryId = 2
                },

            new Product
            {
                ProductId = 2,
                Name = "chicken taco",
                Description = "a delicious chicken taco",
                Price = 1.99m,
                Stock = 101,
                CatagoryId = 2
            },

             new Product
             {
                 ProductId = 3,
                 Name = "fish taco",
                 Description = "a delicious fish taco",
                 Price = 3.99m,
                 Stock = 90,
                 CatagoryId = 2
             }
                ); 
            modelBuilder.Entity<ProductIngredient>().HasData(
                new ProductIngredient { ProductId = 1, IngredientId = 1 },
                new ProductIngredient { ProductId = 1, IngredientId = 4 },
                new ProductIngredient { ProductId = 1, IngredientId = 5 },
                new ProductIngredient { ProductId = 1, IngredientId = 6 },
                new ProductIngredient { ProductId = 2, IngredientId = 2 },
                new ProductIngredient { ProductId = 2, IngredientId = 4 },
                new ProductIngredient { ProductId = 2, IngredientId = 5 },
                new ProductIngredient { ProductId = 2, IngredientId = 6 },
                new ProductIngredient { ProductId = 3, IngredientId = 3 },
                new ProductIngredient { ProductId = 3, IngredientId = 4 },
                new ProductIngredient { ProductId = 3, IngredientId = 5 },
                new ProductIngredient { ProductId = 3, IngredientId = 6 }
                );
        }
    }
}