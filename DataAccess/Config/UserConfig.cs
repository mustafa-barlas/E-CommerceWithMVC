using Entities.Concrete.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData
        (
            new User()
            {
                Id = 1,
                FirstName = "Okan",
                LastName = "Kara",
                Email = "okan@gmail.com",
                IsActive = true,
                Password = "123456",
                RoleId = 1
            },
            new User()
            {
                Id = 2,
                FirstName = "Ceyda",
                LastName = "Yıldırım",
                Email = "ceyda@gmail.com",
                IsActive = true,
                Password = "123456",
                RoleId = 2
            }
        );
    }
}