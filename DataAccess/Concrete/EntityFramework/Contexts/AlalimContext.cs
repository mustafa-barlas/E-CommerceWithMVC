using System.Reflection;
using Entities.Concrete;
using Entities.Concrete.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts;

public class AlalimContext : DbContext
{

    public DbSet<Product> Products { get; set; }

    public DbSet<Color> Colors { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<ProductOrder> ProductOrders { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Address> Addresses { get; set; }

    public DbSet<City> Cities { get; set; }

    //public DbSet<User> Users { get; set; }

    //public DbSet<OperationClaim> OperationClaims { get; set; }

    //public DbSet<UserOperationClaim> UserOperationClaims { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer("Server = MBARLAS\\SQLEXPRESS; DataBase = AlalimStore; Trusted_Connection=true ; TrustServerCertificate=True");

        //optionsBuilder.UseLazyLoadingProxies(); enable the Lazy loading

        // Or

        //optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server = MBARLAS\\SQLEXPRESS;DataBase = AlalimStore; Trusted_Connection=true ; TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // For config file

        base.OnModelCreating(modelBuilder);

        // Product for category
        modelBuilder.Entity<Product>()
            .HasOne(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);




        // OrderProduct 
        modelBuilder.Entity<ProductOrder>()
            .HasKey(op => new { op.OrderID, op.ProductID });

        modelBuilder.Entity<ProductOrder>()
            .HasOne(op => op.Order)
            .WithMany(o => o.ProductOrders)
            .HasForeignKey(op => op.OrderID);


        modelBuilder.Entity<ProductOrder>()
            .HasOne(op => op.Product)
            .WithMany(p => p.ProductOrders)
            .HasForeignKey(op => op.ProductID);



        // Address for user
        modelBuilder.Entity<Address>()
            .HasOne(a => a.User)
            .WithMany(u => u.Addresses)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.SetNull);

        // Address for city
        modelBuilder.Entity<Address>()
            .HasOne(a => a.City)
            .WithMany(c => c.Addresses)
            .HasForeignKey(a => a.CityId);

    }
}