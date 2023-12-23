using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class AddressConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasData
        (
            new Address()
            {
                AddressId = 1,
                Title = "Ev Adresi",
                CityId = 1,
                UserId = 1,
                District = "Beşiktaş",
                Street = "Abc sokak",
                PhoneNumber = "0152455252",
                DetailedAddress = "Yeni mahale abc apartman no: 45 daire:6"

            },
            new Address()
            {
                AddressId = 2,
                Title = "İş Adresi",
                CityId = 2,
                UserId = 2,
                District = "Mamak",
                Street = "Abc sokak",
                PhoneNumber = "0152455252",
                DetailedAddress = "Yeni mahale abc apartman no: 45 daire:6"

            }
        );
    }
}