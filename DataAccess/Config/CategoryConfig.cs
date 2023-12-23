using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
             builder.Property(c => c.Name).IsRequired();

             builder.HasData(
                new Category() { Id = 1, Name = "Smart Phone" },
                new Category() { Id = 2, Name = "Apple" }
            );
        }
    }
}