
namespace CarDealershipSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
    using Models;

    public class CarEntiyConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                .Property(c => c.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property(c => c.IsActive)
                .HasDefaultValue(true);

            builder
                .HasOne(c => c.Seller)
                .WithMany(s => s.CarsForSale)
                .HasForeignKey(c => c.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Category)
                .WithMany(ct => ct.Cars)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.TransmissionType)
                .WithMany(tt => tt.Cars)
                .HasForeignKey(c => c.TransmissionTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.FuelType)
                .WithMany(ft => ft.Cars)
                .HasForeignKey(c => c.FuelTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.GenerateCars());
        }

        private Car[] GenerateCars()
        {
            ICollection<Car> cars = new HashSet<Car>();

            Car car;

            car = new Car()
            {
                Make = "BMW",
                Model = "330i",
                Description = "Experience the epitome of driving pleasure with this BMW 330i. With its sleek design, powerful engine, and advanced technology, this luxury sedan offers an exhilarating driving experience.",
                Year = 2006,
                Kilometers = 150000,
                Horsepower = 258,
                Price = 15550,
                ImageUrl = "https://i.pinimg.com/originals/ce/d9/5e/ced95e743efd9f0b5b182c6d4a9d4ef7.jpg",
                CategoryId = 1,
                FuelTypeId = 1,
                TransmissionTypeId = 1,
                SellerId = Guid.Parse("03C64B16-D297-4440-A62C-216517B1C8D4")
            };
            cars.Add(car);

            car = new Car()
            {
                Make = "BMW",
                Model = "M4",
                Description = "Unleash the ultimate driving experience with the 2022 BMW M4. Boasting a powerful twin-turbocharged inline-six engine, dynamic handling, and aggressive styling, this sports coupe is engineered to thrill at every turn. With its luxurious interior, cutting-edge technology, and track-ready performance, the BMW M4 sets the standard for exhilarating driving. Don't miss out on the opportunity to own this icon of performance and precision.",
                Year = 2022,
                Kilometers = 10278,
                Horsepower = 503,
                Price = 105000,
                ImageUrl = "https://supercars.bg/wp-content/uploads/2022/05/P90458876_highRes_new-edition-of-a-leg.jpg",
                CategoryId = 3,
                FuelTypeId = 1,
                TransmissionTypeId = 2,
                SellerId = Guid.Parse("03C64B16-D297-4440-A62C-216517B1C8D4")
            };
            cars.Add(car);

            return cars.ToArray();
        }
    }
}
