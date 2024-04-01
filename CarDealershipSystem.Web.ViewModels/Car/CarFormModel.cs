﻿using CarDealershipSystem.Web.ViewModels.Category;
using CarDealershipSystem.Web.ViewModels.FuelType;
using CarDealershipSystem.Web.ViewModels.TransmissionType;
using System.ComponentModel.DataAnnotations;

namespace CarDealershipSystem.Web.ViewModels.Car
{
    using static Common.EntityValidationConstants.Car;
    public class CarFormModel
    {
        public CarFormModel()
        {
            this.Categories = new HashSet<CarSelectCategoryFormModel>();
            this.FuelTypes = new HashSet<CarSelectFuelTypeFormModel>();
            this.TransmissionTypes = new HashSet<CarSelectTransmissionTypeFormModel>();
            this.SelectedExtrasIds = new HashSet<int>();
        }

        [Required]
        [StringLength(MakeMaxLength, MinimumLength = MakeMinLength)]
        public string Make { get; set; } = null!;

        [Required]
        [StringLength(ModelMaxLength, MinimumLength = ModelMinLength)]
        public string Model { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        public int Year { get; set; }

        public int Kilometers { get; set; }

        public int Horsepower { get; set; }

        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(ImageUrlMaxLength)]
        [Display(Name = "Image link")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CarSelectCategoryFormModel> Categories { get; set; }

        [Display(Name = "Fuel Type")]
        public int FuelTypeId { get; set; }

        public IEnumerable<CarSelectFuelTypeFormModel> FuelTypes { get; set; }

        [Display(Name = "Transmission Type")]
        public int TransmissionTypeId { get; set; }

        public IEnumerable<CarSelectTransmissionTypeFormModel> TransmissionTypes { get; set; }

        public IEnumerable<int> SelectedExtrasIds { get; set; }
    }
}
