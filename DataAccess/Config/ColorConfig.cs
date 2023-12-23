using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataAccess.Config
{
    public class ColorConfig : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
           
           builder.HasData
           (
            new Color(){Id = 1,Name = "Red"},
            new Color(){Id = 2,Name = "Blue"},
            new Color(){Id = 3,Name = "Yellow"}
            
           );
        }
    }
}