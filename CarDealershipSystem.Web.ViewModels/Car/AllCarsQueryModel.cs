namespace CarDealershipSystem.Web.ViewModels.Car
{
    using System.ComponentModel.DataAnnotations;

    using Enums;

    using static Common.GeneralApplicationConstants;

    public class AllCarsQueryModel
    {
        public AllCarsQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.CarsPerPage = EntitiesPerPage;

            this.Categories = new HashSet<string>();
            this.Cars = new HashSet<CarAllViewModel>();
        }

        public string? Category { get; set; }

        [Display(Name = "Search by word")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort Cars By")]
        public CarSorting CarSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Show Cars On Page")]
        public int CarsPerPage { get; set; }

        public int TotalCars { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<CarAllViewModel> Cars { get; set; }
    }
}
