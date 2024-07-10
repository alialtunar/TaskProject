using Microsoft.EntityFrameworkCore;
using TaskProject.EntityLayer.Concreate;

namespace TaskProject.DataAccessLayer.Concreate
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

        // DbSet codes for database tables
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationship between Product and Category (one to many relationships)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            // Database type for the Price field (so that it does not generate error and warning messages)
            modelBuilder.Entity<Product>()
               .Property(p => p.Price)
               .HasColumnType("decimal(18,2)");

            // We add initial category data
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Books" },
                new Category { Id = 3, Name = "Clothing" },
                new Category { Id = 4, Name = "Toys" }
            );

            // We add initial product data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Description = "High performance laptop", Price = 1500.00m, ImageUrl = "https://ssl-product-images.www8-hp.com/digmedialib/prodimg/lowres/c08478684.png", CategoryId = 1 },
                new Product { Id = 4, Name = "Tablet", Description = "10 inch tablet", Price = 400.00m, ImageUrl = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/lenovo/thumb/untitled-1-3_large.jpg", CategoryId = 1 },
                new Product { Id = 6, Name = "Book 1", Description = "Interesting book", Price = 20.00m, ImageUrl = "https://www.panelkirtasiye.com/productimages/468746/big/9786258431254_1.jpg", CategoryId = 2 },
                new Product { Id = 9, Name = "Toy Car", Description = "Remote-controlled toy car", Price = 45.00m, ImageUrl = "https://cdn.civilim.com/productimages/353321/big/86992623400652.jpg", CategoryId = 4 },
                new Product { Id = 10, Name = "Summer Dress", Description = "Light and stylish summer dress", Price = 85.00m, ImageUrl = "https://i.ebayimg.com/images/g/OoIAAOSwqMtdmUEp/s-l1600.jpg", CategoryId = 3 },
                new Product { Id = 5, Name = "Monitor", Description = "4K monitor", Price = 350.00m, ImageUrl = "https://www.casper.com.tr/uploads/2023/09/casper-nirvana-238-monitor-03_op.webp", CategoryId = 1 },
                new Product { Id = 7, Name = "Book 2", Description = "Interesting book", Price = 60.00m, ImageUrl = "https://img.kitapyurdu.com/v1/getImage/fn:5847593/wh:true/wi:800", CategoryId = 2 },
                new Product { Id = 2, Name = "Smartphone", Description = "Latest model smartphone", Price = 999.00m, ImageUrl = "https://cdn.cimri.io/image/1200x1200/apple-iphone-15-5g-128gb_865272811.jpg", CategoryId = 1 },
                new Product { Id = 3, Name = "Headphones", Description = "Noise cancelling headphones", Price = 199.00m, ImageUrl = "https://enteknoloji.com.tr/cdn/shop/files/air-3-bluetooth-kulaklik-1.1.png?v=1693815672&width=2048", CategoryId = 1 }
             


            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
