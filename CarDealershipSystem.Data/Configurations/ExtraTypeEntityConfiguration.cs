namespace CarDealershipSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class ExtraTypeEntityConfiguration : IEntityTypeConfiguration<ExtraType>
    {
        public void Configure(EntityTypeBuilder<ExtraType> builder)
        {
            builder.HasData(this.GenerateExtraTypes());
        }

        private ExtraType[] GenerateExtraTypes()
        {
            ICollection<ExtraType> extraTypes = new HashSet<ExtraType>();

            ExtraType extraType;

            extraType = new ExtraType()
            {
                Id = 1,
                Name = "Comfort"
            };
            extraTypes.Add(extraType);

            extraType = new ExtraType()
            {
                Id = 2,
                Name = "Safety"
            };
            extraTypes.Add(extraType);

            extraType = new ExtraType()
            {
                Id= 3,
                Name = "Other"
            };
            extraTypes.Add(extraType);

            return extraTypes.ToArray();
        }
    }
}
