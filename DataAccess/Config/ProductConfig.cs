using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductId);
            builder.Property(x => x.ProductName).IsRequired();

            builder.HasData
            (
             new Product() { ProductId = 1, CategoryId = 1, ImageUrl = "/img/1.jpg", ProductName = "Iphone 11 Pro Max", ColorId = 1, Description = "256 GB", Summary = "Silver", Price = 699, ShowCase = true, Status = true },
             new Product() { ProductId = 2, CategoryId = 2, ImageUrl = "/img/2.jpg", ProductName = "Iphone 12 Pro Max", ColorId = 2, Description = "256 GB", Summary = "Black", Price = 799, ShowCase = true, Status = true },
             new Product() { ProductId = 3, CategoryId = 3, ImageUrl = "/img/3.jpg", ProductName = "Iphone 13 Pro Max", ColorId = 3, Description = "256 GB", Summary = "White", Price = 899, ShowCase = true, Status = true },
             new Product() { ProductId = 4, CategoryId = 1, ImageUrl = "/img/4.jpg", ProductName = "Iphone 14 Pro Max", ColorId = 1, Description = "256 GB", Summary = "White", Price = 999, ShowCase = true, Status = true },
             new Product() { ProductId = 5, CategoryId = 2, ImageUrl = "/img/5.jpg", ProductName = "Iphone 15 Pro Max", ColorId = 2, Description = "256 GB", Summary = "White", Price = 1099, ShowCase = true, Status = true },
             new Product() { ProductId = 6, CategoryId = 3, ImageUrl = "/img/6.jpg", ProductName = "Iphone 16 Pro Max", ColorId = 3, Description = "256 GB", Summary = "White", Price = 1199, ShowCase = true, Status = true },
             new Product() { ProductId = 7, CategoryId = 1, ImageUrl = "/img/7.jpg", ProductName = "Iphone 17 Pro Max", ColorId = 1, Description = "256 GB", Summary = "White", Price = 1299, ShowCase = true, Status = true },
             new Product() { ProductId = 8, CategoryId = 2, ImageUrl = "/img/8.jpg", ProductName = "Iphone 18 Pro Max", ColorId = 2, Description = "256 GB", Summary = "White", Price = 1399, ShowCase = true, Status = true },
             new Product() { ProductId = 9, CategoryId = 3, ImageUrl = "/img/9.jpg", ProductName = "Iphone 19 Pro Max", ColorId = 3, Description = "256 GB", Summary = "White", Price = 1499, ShowCase = true, Status = true },
             new Product() { ProductId = 10, CategoryId = 3, ImageUrl = "/img/10.jpg", ProductName = "Iphone 20 Pro Max", ColorId = 1, Description = "256 GB", Summary = "White", Price = 1599, ShowCase = true, Status = true }
            );
        }
    }
}