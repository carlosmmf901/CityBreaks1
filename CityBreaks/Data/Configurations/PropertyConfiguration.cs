using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CityBreaks.Web.Models;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(150)
            .HasColumnName("Property_Name");

        builder.HasData(
            new Property { Id = 1, Name = "Hotel Paulista", PricePerNight = 250, CityId = 1 },
            new Property { Id = 2, Name = "Copacabana Palace", PricePerNight = 500, CityId = 2 },
            new Property { Id = 3, Name = "NY Downtown Loft", PricePerNight = 700, CityId = 3 }
        );
    }
}