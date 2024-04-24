namespace CarDealershipSystem.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using System.Reflection;

    using CarDealershipSystem.Data.Models;

    public class CarDealershipDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public CarDealershipDbContext(DbContextOptions<CarDealershipDbContext> options)
            : base(options)
        {
        }

        public DbSet<Seller> Seller { get; set; } = null!;

        public DbSet<Car> Cars { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Extra> Extra { get; set; } = null!;

        public DbSet<ExtraType> ExtraTypes { get; set; } = null!;

        public DbSet<CarExtra> CarExtras { get; set; } = null!;

        public DbSet<FuelType> FuelTypes { get; set; } = null!;

        public DbSet<TransmissionType> TransmissionTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(CarDealershipDbContext)) ??
                                      Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}