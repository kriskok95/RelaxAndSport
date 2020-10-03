namespace RelaxAndSport.Domain.Booking.Factories.Trainings
{
    using RelaxAndSport.Domain.Booking.Exceptions;
    using RelaxAndSport.Domain.Booking.Models.Trainings;
    using System;

    internal class TrainingsFactory : ITrainingsFactory
    {
        private string type = default!;
        private Trainer trainer = default!;
        private DateTime date = default;
        private int slots = default;
        private decimal price = default;
        private bool isRepeated = default;

        private bool typeSet = false;
        private bool trainerSet = false;
        private bool dateSet = false;
        private bool slotsSet = false;
        private bool priceSet = false;

        public ITrainingsFactory WithType(string type)
        {
            this.type = type;
            this.typeSet = true;
            return this;
        }

        public ITrainingsFactory WithTrainer(string firstName, string lastName)
            => this.WithTrainer(new Trainer(firstName, lastName));

        public ITrainingsFactory WithTrainer(Trainer trainer)
        {
            this.trainer = trainer;
            trainerSet = true;
            return this;
        }

        public ITrainingsFactory WithDate(DateTime date)
        {
            this.date = date;
            this.dateSet = true;
            return this;
        }

        public ITrainingsFactory WithSlots(int slots)
        {
            this.slots = slots;
            this.slotsSet = true;
            return this;
        }

        public ITrainingsFactory WithPrice(decimal price)
        {
            this.price = price;
            this.priceSet = true;
            return this;
        }

        public ITrainingsFactory WithIsRepeated(bool isRepeated)
        {
            this.isRepeated = isRepeated;
            return this;
        }

        public Training Build()
        {
            if(
                !typeSet || 
                !trainerSet ||
                !dateSet ||
                !slotsSet ||
                !priceSet)
            {
                throw new InvalidTrainingException("Training type, trainer, date, slots and price must have a value.");
            }

            return new Training(
                this.type,
                this.trainer,
                this.date,
                this.slots,
                this.price,
                this.isRepeated);
        }
    }
}
