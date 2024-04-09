namespace CarDealershipSystem.Services.Data
{
    using Web.ViewModels.Home;
    using Web.Data;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using CarDealershipSystem.Web.ViewModels.Car;
    using CarDealershipSystem.Data.Models;
    using System.Collections.Generic;
    using CarDealershipSystem.Services.Data.Models.Car;
    using CarDealershipSystem.Web.ViewModels.Car.Enums;
    using System.Text.RegularExpressions;

    public class CarService : ICarService
    {
        private readonly CarDealershipDbContext dbContext;

        public CarService(CarDealershipDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<IndexViewModel>> LastFiveCarsAsync()
        {
            IEnumerable<IndexViewModel> lastFiveCars = await this.dbContext
                .Cars
                .Where(c => c.IsActive)
                .OrderByDescending(c => c.CreatedOn)
                .Take(5)
                .Select(c => new IndexViewModel()
                {
                    Id = c.Id.ToString(),
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    Horsepower = c.Horsepower,
                    FuelType = c.FuelType.Name,
                    TransmissionType = c.TransmissionType.Name,
                    Price = c.Price,
                    ImageUrl = c.ImageUrl,
                    CreatedOn = c.CreatedOn
                })
                .ToArrayAsync();

            return lastFiveCars;
        }

        public async Task CreateAsync(CarFormModel formModel, string sellerId, List<Guid> selectedExtrasIds)
        {
            Car newCar = new Car()
            {
                Make = formModel.Make,
                Model = formModel.Model,
                Description = formModel.Description,
                Year = formModel.Year,
                Kilometers = formModel.Kilometers,
                Horsepower = formModel.Horsepower,
                Price = formModel.Price,
                ImageUrl = formModel.ImageUrl,
                CategoryId = formModel.CategoryId,
                FuelTypeId = formModel.FuelTypeId,
                TransmissionTypeId = formModel.TransmissionTypeId,
                SellerId = Guid.Parse(sellerId),
            };

            if (selectedExtrasIds.Any())
            {
                foreach (var extraId in selectedExtrasIds)
                {
                    var extra = this.dbContext
                        .Extra
                        .FirstOrDefault(e => e.Id == extraId);

                    if (extra != null)
                    {
                        this.dbContext.Attach(extra);

                        newCar.CarExtras.Add(new CarExtra
                        {
                            Extra = extra,
                            Car = newCar,
                        });
                    }
                }
            }

            await this.dbContext.Cars.AddAsync(newCar);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<AllCarsFilteredAndPagedServiceModel> AllAsync(AllCarsQueryModel queryModel)
        {
            IQueryable<Car> carsQuery = this.dbContext
                .Cars
                .Where(c => c.IsActive)
                .AsQueryable();

            if(!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                carsQuery = carsQuery
                    .Where(c => c.Category.Name == queryModel.Category);
            }

            if(!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";
                carsQuery = carsQuery
                    .Where(c => EF.Functions.Like(c.Make, wildCard) ||
                                EF.Functions.Like(c.Model, wildCard) ||
                                EF.Functions.Like(c.TransmissionType.Name, wildCard) ||
                                EF.Functions.Like(c.Category.Name, wildCard) ||
                                EF.Functions.Like(c.FuelType.Name, wildCard) ||
                                EF.Functions.Like(c.Description, wildCard));
            }

            carsQuery = queryModel.CarSorting switch
            {
                CarSorting.Newest => carsQuery
                    .OrderByDescending(c => c.CreatedOn),
                CarSorting.Oldest => carsQuery
                    .OrderBy(c => c.CreatedOn),
                CarSorting.PriceAscending => carsQuery
                    .OrderBy(c => c.Price),
                CarSorting.PriceDescending => carsQuery
                    .OrderByDescending(c => c.Price),
                CarSorting.ManufactureYearAscending => carsQuery
                    .OrderBy(c => c.Year),
                CarSorting.ManufactureYearDescending => carsQuery
                    .OrderByDescending(c => c.Year)
            };

            IEnumerable<CarAllViewModel> allCars = await carsQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.CarsPerPage)
                .Take(queryModel.CarsPerPage)
                .Select(c => new CarAllViewModel
                {
                    Id = c.Id.ToString(),
                    Make = c.Make,
                    Model = c.Model,
                    Description = Regex.Match(c.Description, @"^.*?[\.\?\!](?=\s[A-Z]|\s*$)").ToString(),
                    Year = c.Year,
                    Horsepower = c.Horsepower,
                    Category = c.Category.Name,
                    FuelType = c.FuelType.Name,
                    TransmissionType = c.TransmissionType.Name,
                    Kilometers = c.Kilometers,
                    Price = c.Price,
                    ImageUrl = c.ImageUrl,
                    CreatedOn = c.CreatedOn,
                    LocationCountry = c.Seller.LocationCountry,
                    LocationCity = c.Seller.LocationCity
                })
                .ToArrayAsync();

            int totalCars = carsQuery.Count();

            return new AllCarsFilteredAndPagedServiceModel()
            {
                TotalCarsCount = totalCars,
                Cars = allCars
            };
        }
    }
}
