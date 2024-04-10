using CarDealershipSystem.Web.ViewModels.Seller;

namespace CarDealershipSystem.Web.ViewModels.Car
{
    public class CarDetailsViewModel : CarAllViewModel
    {
        public CarDetailsViewModel()
        {
            this.ComfortExtras = new HashSet<string>();
            this.SafetyExtras = new HashSet<string>();
            this.OtherExtras = new HashSet<string>();
        }

        public ICollection<string> ComfortExtras { get; set; }

        public ICollection<string> SafetyExtras { get; set; }

        public ICollection<string> OtherExtras { get; set; }

        public SellerInfoOnCarDetailsViewModel Seller { get; set; } = null!;
    }
}
