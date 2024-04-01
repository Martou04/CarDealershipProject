namespace CarDealershipSystem.Data.Models
{
    public class CarExtra
    {
        public Guid CarId { get; set; }

        public virtual Car Car { get; set; } = null!;

        public Guid ExtraId { get; set; }

        public virtual Extra Extra { get; set; } = null!;
    }
}
