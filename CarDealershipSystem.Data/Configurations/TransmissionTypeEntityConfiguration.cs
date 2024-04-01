namespace CarDealershipSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class TransmissionTypeEntityConfiguration : IEntityTypeConfiguration<TransmissionType>
    {
        public void Configure(EntityTypeBuilder<TransmissionType> builder)
        {
            builder.HasData(this.GenerateTransmissionType());
        }

        private TransmissionType[] GenerateTransmissionType()
        {
            ICollection<TransmissionType> transmissionTypes = new HashSet<TransmissionType>();

            TransmissionType transmissionType;

            transmissionType = new TransmissionType()
            {
                Id = 1,
                Name = "Manual"
            };
            transmissionTypes.Add(transmissionType);

            transmissionType = new TransmissionType()
            {
                Id= 2,
                Name = "Automatic"
            };
            transmissionTypes.Add(transmissionType);

            transmissionType = new TransmissionType()
            {
                Id = 3,
                Name = "Semi-Automatic"
            };
            transmissionTypes.Add(transmissionType);

            return transmissionTypes.ToArray();
        }
    }
}
