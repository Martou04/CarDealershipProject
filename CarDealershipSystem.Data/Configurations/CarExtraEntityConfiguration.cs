

namespace CarDealershipSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;
    public class CarExtraEntityConfiguration : IEntityTypeConfiguration<CarExtra>
    {
        public void Configure(EntityTypeBuilder<CarExtra> builder)
        {
            builder
                .HasKey(ce => new { ce.CarId, ce.ExtraId });

            builder
                .HasOne(ce => ce.Car)
                .WithMany(e => e.CarExtras)
                .HasForeignKey(ce =>  ce.ExtraId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
