using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts;

public class AlalimContext : DbContext
{

    public DbSet<Product> Products { get; set; }

    public DbSet<Color> Colors { get; set; }

    public DbSet<ProductColor> ProductColors { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public DbSet<ProductSize> ProductSizes { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<OperationClaim> OperationClaims { get; set; }

    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer("Server = MBARLAS\\SQLEXPRESS;DataBase = AlalimStore; Trusted_Connection=true ; TrustServerCertificate=True");

        //optionsBuilder.UseLazyLoadingProxies(); enable the Lazy loading
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasOne(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId);

        modelBuilder.Entity<ProductTag>().HasKey(x => new { x.ProductId, x.TagId });

        modelBuilder.Entity<ProductTag>()
            .HasOne(x => x.Product)
            .WithMany(x => x.ProductTags)
            .HasForeignKey(x => x.ProductId);

        modelBuilder.Entity<ProductTag>()
            .HasOne(x => x.Tag)
            .WithMany(x => x.ProductTags)
            .HasForeignKey(x => x.TagId);

        // Many-to-Many ilişkisi
        modelBuilder.Entity<ProductColor>()
            .HasKey(pc => new { pc.ProductId, pc.ColorId });

        modelBuilder.Entity<ProductColor>()
            .HasOne(pc => pc.Product)
            .WithMany(p => p.ProductColors)
            .HasForeignKey(pc => pc.ProductId);

        modelBuilder.Entity<ProductColor>()
            .HasOne(pc => pc.Color)
            .WithMany(c => c.ProductColors)
            .HasForeignKey(pc => pc.ColorId);
    }
}
