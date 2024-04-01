namespace CarDealershipSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.ApplicationUser;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.BoughtCars = new HashSet<Car>();
        }

        public virtual ICollection<Car> BoughtCars { get; set; }
    }
}
