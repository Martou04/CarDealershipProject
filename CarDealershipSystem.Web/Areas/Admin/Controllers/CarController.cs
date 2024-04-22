﻿using CarDealershipSystem.Services.Data.Interfaces;
using CarDealershipSystem.Web.Areas.Admin.ViewModels.Car;
using CarDealershipSystem.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CarDealershipSystem.Web.Areas.Admin.Controllers
{
    public class CarController : BaseAdminController
    {
        private readonly ISellerService sellerService;
        private readonly ICarService carService;

        public CarController(ISellerService sellerService, ICarService carService)
        {
            this.sellerService = sellerService;
            this.carService = carService;
        }

        public async Task<IActionResult> Mine()
        {
            string? sellerId = 
                await this.sellerService.GetSellerIdByUserIdAsync(this.User.GetId()!);
            MyCarsViewModel viewModel = new MyCarsViewModel()
            {
                AddedCars = await this.carService.AllBySellerIdAsync(sellerId!),
            };

            return this.View(viewModel);
        }
    }
}
