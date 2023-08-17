using e_commerce.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Color> Colors { get; set; }
        //public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        //public DbSet<ProductSize> ClothSizes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Look> Looks { get; set; }
        public DbSet<ProductLook> ProductLooks { get; set; }
        public DbSet<ProductStyle> ProductStyle { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ShoppingCart>().ToTable("ShoppingCart");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Color>().ToTable("Color");
            //modelBuilder.Entity<ProductColor>().ToTable("ProductColor");
            //modelBuilder.Entity<ProductSize>().ToTable("ProductSize");
            modelBuilder.Entity<Size>().ToTable("Size");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<SubCategory>().ToTable("SubCategory");
            modelBuilder.Entity<ProductCategory>().ToTable("ProductCategory");
            modelBuilder.Entity<Gender>().ToTable("Gender");
            modelBuilder.Entity<Season>().ToTable("Season");
            modelBuilder.Entity<Brand>().ToTable("Brand");
            modelBuilder.Entity<Material>().ToTable("Material");
            modelBuilder.Entity<Look>().ToTable("Look");
            modelBuilder.Entity<ProductLook>().ToTable("ProductLook");
            modelBuilder.Entity<ProductStyle>().ToTable("ProductStyle");
            //modelBuilder.Entity<Order>().ToTable("Order");
        }
    }
}
