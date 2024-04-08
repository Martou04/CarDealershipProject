namespace CarDealershipSystem.Services.Data
{
    using Web.ViewModels.Home;
    using Web.Data;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using CarDealershipSystem.Web.ViewModels.Car;
    using CarDealershipSystem.Data.Models;
    using CarDealershipSystem.Web.ViewModels.CarExtra;
    using System.Collections.Generic;


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
        
    }
}
