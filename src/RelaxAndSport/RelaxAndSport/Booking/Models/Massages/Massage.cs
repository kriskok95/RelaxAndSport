namespace RelaxAndSport.Domain.Booking.Models.Massages
{
    using RelaxAndSport.Domain.Booking.Exceptions;
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.Common.Models;

    using static RelaxAndSport.Domain.Common.Models.ModelConstants.Common;
    using static RelaxAndSport.Domain.Common.Models.ModelConstants.Massage;

    public class Massage : Entity<int>, IAggregateRoot
    {
        internal Massage(
            string category,
            string description,
            int duration,
            decimal price)
        {
            Validate(category, description, duration, price);

            this.Category = category;
            this.Description = description;
            this.Duration = duration;
            this.Price = price;
        }

        public string Category { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public int Duration { get; private set; }

        public Massage UpdateCategory(string category)
        {
            this.ValidateCategory(category);
            this.Category = category;
            return this;
        }

        public Massage UpdateDescription(string description)
        {
            this.ValidateDescription(description);
            this.Description = description;

            return this;
        }

        public Massage UpdatePrice(decimal price)
        {
            this.ValidatePrice(price);
            this.Price = price;

            return this;
        }

        public Massage UpdateDuration(int duration)
        {
            this.ValidateDuration(duration);
            this.Duration = duration;

            return this;
        }

        private void Validate(string category, string description, int duration, decimal price)
        {
            ValidateCategory(category);
            ValidateDescription(description);
            ValidateDuration(duration);
            ValidatePrice(price);
        }

        private void ValidateCategory(string category)
            => Guard.ForStringLength<InvalidMassageException>(
                category,
                MinNameLength,
                MaxNameLength,
                nameof(category));

        private void ValidateDescription(string description)
            => Guard.ForStringLength<InvalidMassageException>(
                description,
                MinDescriptionLength,
                MaxDescriptionLength,
                nameof(description));

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
