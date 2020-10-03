namespace RelaxAndSport.Domain.Booking.Models.Trainings
{
    using RelaxAndSport.Domain.Booking.Exceptions;
    using RelaxAndSport.Domain.Common;
    using System;

    using static RelaxAndSport.Domain.Common.Models.ModelConstants.Training;

    public class Training : Entity<int>, IAggregateRoot
    {
        internal Training(
            string type,
            Trainer trainer,
            DateTime date,
            int slots,
            decimal price,
            bool isRepeated)
        {
            Validate(type, date, slots, price);

            this.Type = type;
            this.Trainer = trainer;
            this.Date = date;
            this.Slots = slots;
            this.Price = price;
            this.IsRepeated = isRepeated;
        }

        public string Type { get; private set; }

        public Trainer Trainer { get; private set; }

        public DateTime Date { get; private set; }

        public int Slots { get; private set; }

        public decimal Price { get; private set; }

        public bool IsRepeated { get; private set; }

        private void Validate(
            string type,
            DateTime date,
            int slots,
            decimal price)
        {
            ValidateType(type);
            ValidateDate(date);
            ValidateSlots(slots);
            ValidatePrice(price);
        }

        private void ValidateType(string type)
            => Guard.AgainstEmptyString<InvalidTrainingException>(
                type,
                nameof(type));

        private void ValidateDate(DateTime date)
            => Guard.AgainstDateRange<InvalidTrainingException>(
                date,
                DateTime.UtcNow,
                nameof(date));

        private void ValidateSlots(int slots)
            => Guard.AgainstOutOfRange<InvalidTrainingException>(
                slots,
                MinNumberOfSlots,
                MaxNumberOfSlots);

        private void ValidatePrice(decimal price)
            => Guard.AgainstOutOfRange<InvalidTrainingException>(
                price,
                MinPrice,
                MaxPrice,
                nameof(price));
    }
}
