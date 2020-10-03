namespace RelaxAndSport.Domain.MassagesBooking.Models.Massages
{
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.MassagesBooking.Exceptions;

    using static RelaxAndSport.Domain.Common.Models.ModelConstants.Massage;

    public class Massage : Entity<int>, IAggregateRoot
    {
        internal Massage(
            Type type,
            int duration,
            decimal price)
        {
            Validate(duration, price);

            this.Type = type;
            this.Price = price;
        }

        public Type Type { get; private set; }

        public decimal Price { get; private set; }

        private void Validate(int duration, decimal price)
        {
            ValidateDuration(duration);
            ValidatePrice(price);
        }

        private void ValidateDuration(int duration)
            => Guard.AgainstOutOfRange<InvalidMassageException>(
                duration,
                MinDuration,
                MaxDuration,
                nameof(duration));

        private void ValidatePrice(decimal price)
            => Guard.AgainstOutOfRange<InvalidMassageException>(
                price,
                MinPrice,
                MaxPrice,
                nameof(price));
    }
}
