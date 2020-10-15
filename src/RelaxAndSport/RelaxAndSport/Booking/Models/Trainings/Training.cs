namespace RelaxAndSport.Domain.Booking.Models.Trainings
{
    using RelaxAndSport.Domain.Booking.Exceptions;
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.Common.Models;
    using System;
    using static RelaxAndSport.Domain.Common.Models.ModelConstants.Training;

    public class Training : Entity<int>, IAggregateRoot
    {
        internal Training(
            string category,
            Trainer trainer,
            DateTime date,
            int duration,
            int slots,
            decimal price,
            bool isRepeated)
        {
            Validate(category, date, duration, slots, price);

            this.Category = category;
            this.Trainer = trainer;
            this.Date = date;
            this.Duration = duration;
            this.Slots = slots;
            this.Price = price;
            this.IsRepeated = isRepeated;
        }

        private Training(
            string category,
            int slots,
            int duration,
            decimal price,
            bool isRepeated)
        {
            this.Category = category;
            this.Trainer = default!;
            this.Date = default;
            this.Duration = duration;
            this.Slots = slots;
            this.Price = price;
            this.IsRepeated = isRepeated;
        }

        public string Category { get; private set; }

        public Trainer Trainer { get; private set; }

        public DateTime Date { get; private set; }

        public int Duration { get; private set; }

        public int Slots { get; private set; }

        public decimal Price { get; private set; }

        public bool IsRepeated { get; private set; }

        public Training UpdateCategory(string category) 
        {
            this.ValidateCategory(category);
            this.Category = category;

            return this;
        }

        public Training UpdateTrainer(Trainer trainer)
        {
            this.Trainer = trainer;

            return this;
        }

        public Training UpdateDate(DateTime date)
        {
            this.ValidateDate(date);
            this.Date = date;

            return this;
        }

        public Training UpdateDuration(int duration)
        {
            this.ValidateDuration(duration);
            this.Duration = duration;

            return this;
        }

        public Training UpdateSlots(int slots)
        {
            this.ValidateSlots(slots);
            this.Slots = slots;

            return this;
        }

        public Training UpdatePrice(decimal price)
        {
            this.ValidatePrice(price);
            this.Price = price;

            return this;
        }

        public Training UpdateIsRepeated(bool isRepeated)
        {
            this.IsRepeated = isRepeated;

            return this;
        }

        private void Validate(
            string category,
            DateTime date,
            int duration,
            int slots,
            decimal price)
        {
            ValidateCategory(category);
            ValidateDate(date);
            ValidateDuration(duration);
            ValidateSlots(slots);
            ValidatePrice(price);
        }

        private void ValidateCategory(string category)
            => Guard.AgainstEmptyString<InvalidTrainingException>(
                category,
                nameof(category));

        private void ValidateDate(DateTime date)
            => Guard.ForValidDate<InvalidTrainingException>(
                date,
                nameof(date));

        private void ValidateDuration(int duration)
            => Guard.AgainstOutOfRange<InvalidTrainingException>(
                duration,
                MinDuration,
                MaxDuration,
                nameof(duration));

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
