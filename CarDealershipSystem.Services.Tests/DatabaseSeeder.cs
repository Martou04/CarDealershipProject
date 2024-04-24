namespace CarDealershipSystem.Services.Tests
{
    using CarDealershipSystem.Web.Data;
    using CarDealershipSystem.Data.Models;
    public static class DatabaseSeeder
    {
        public static ApplicationUser SellerUser;
        public static ApplicationUser User;
        public static Seller Seller;
        public static Car Car;

        public static void SeedDatabase(CarDealershipDbContext dbContext)
        {
            SellerUser = new ApplicationUser()
            {
                UserName = "Pesho",
                NormalizedUserName = "PESHO",
                Email = "pesho@agents.com",
                NormalizedEmail = "PESHO@AGENTS.COM",
                EmailConfirmed = true,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "caf271d7-0ba7-4ab1-8d8d-6d0e3711c27d",
                SecurityStamp = "ca32c787-626e-4234-a4e4-8c94d85a2b1c",
                TwoFactorEnabled = false,
                FirstName = "Pesho",
                LastName = "Petrov"
            };
            dbContext.Users.Add(SellerUser);

            User = new ApplicationUser()
            {
                UserName = "Gosho",
                NormalizedUserName = "GOSHO",
                Email = "gosho@renters.com",
                NormalizedEmail = "GOSHO@RENTERS.COM",
                EmailConfirmed = true,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "8b51706e-f6e8-4dae-b240-54f856fb3004",
                SecurityStamp = "f6af46f5-74ba-43dc-927b-ad83497d0387",
                TwoFactorEnabled = false,
                FirstName = "Gosho",
                LastName = "Goshov"
            };
            dbContext.Users.Add(User);

            Seller = new Seller()
            {
                PhoneNumber = "+359897730222",
                User = SellerUser,
                LocationCountry = "Bulgaria",
                LocationCity = "Sofia"
            };
            dbContext.Seller.Add(Seller);

            Car = new Car()
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
                SellerId = Seller.Id,
                IsActive = true,
                Approved = true
            };
            dbContext.Cars.Add(Car);

            //Add 4 more cars
            for (int i = 0; i < 4; i++)
            {
                var car = new Car()
                {
                    Make = "ExampleMake",
                    Model = $"ExampleModel{i + 1}",
                    Description = $"ExampleDescription{i + 1}",
                    Year = 2022 - i,
                    Kilometers = 50000 + i * 10000,
                    Horsepower = 200 + i * 10,
                    Price = 20000 + i * 5000,
                    ImageUrl = $"https://example.com/car{i + 1}.jpg",
                    CategoryId = 1,
                    FuelTypeId = 1,
                    TransmissionTypeId = 1,
                    SellerId = Seller.Id,
                    IsActive = true,
                    Approved = true
                };
                dbContext.Cars.Add(car);
            }


            dbContext.SaveChanges();
        }
    }
}
