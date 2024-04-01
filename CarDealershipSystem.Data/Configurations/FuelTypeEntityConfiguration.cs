
namespace CarDealershipSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class FuelTypeEntityConfiguration : IEntityTypeConfiguration<FuelType>
    {
        public void Configure(EntityTypeBuilder<FuelType> builder)
        {
            builder.HasData(this.GenerateFuelTypes());
        }

        private FuelType[] GenerateFuelTypes()
        {
            ICollection<FuelType> fuelTypes = new HashSet<FuelType>();

            FuelType fuelType;

            fuelType = new FuelType()
            {
                Id = 1,
                Name = "Gasoline"
            };
            fuelTypes.Add(fuelType);

            fuelType = new FuelType()
            {
                Id = 2,
                Name = "Diesel"
            };
            fuelTypes.Add(fuelType);

            fuelType = new FuelType()
            {
                Id = 3,
                Name = "Electric"
            };
            fuelTypes.Add(fuelType);

            return fuelTypes.ToArray();
        }
    }
}
