using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config;

public class CityConfig : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasData
        (
            new City() { CityId = 1, Name = "İstanbul", Status = true },
            new City() { CityId = 2, Name = "Ankara", Status = true },
            new City() { CityId = 3, Name = "Bursa", Status = true },
            new City() { CityId = 4, Name = "Balıkesir", Status = true },
            new City() { CityId = 5, Name = "Çanakale", Status = true },
            new City() { CityId = 6, Name = "Antalya", Status = true }
        );
    }
}