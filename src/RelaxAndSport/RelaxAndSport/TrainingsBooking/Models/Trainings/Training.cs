namespace RelaxAndSport.Domain.TrainingsBooking.Models.Trainings
{
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.TrainingsBooking.Exceptions;
    using System;

    using static RelaxAndSport.Domain.Common.Models.ModelConstants.Training;

    public class Training : Entity<int>, IAggregateRoot
    {
        internal Training(
            string type,
            Trainer trainer,
            DateTime date,
            int slots,
            bool isRepeated)
        {
            Validate(type, date, slots);

            this.Type = type;
            this.Trainer = trainer;
            this.Date = date;
            this.Slots = slots;
            this.IsRepeated = isRepeated;
        }

        public string Type { get; private set; }

        public Trainer Trainer { get; private set; }

        public DateTime Date { get; private set; }

        public int Slots { get; private set; }

        public bool IsRepeated { get; private set; }

        private void Validate(
            string type,
            DateTime date,
            int slots)
        {
            ValidateType(type);
            ValidateDate(date);
            ValidateSlots(slots);
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
    }
}
