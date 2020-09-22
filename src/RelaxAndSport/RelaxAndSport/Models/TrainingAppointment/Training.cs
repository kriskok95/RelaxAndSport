namespace RelaxAndSport.Domain.Models.TrainingAppointment
{
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.Exceptions;

    public class Training : Entity<int>, IAggregateRoot
    {
        internal Training(
            string type,
            Trainer trainer)
        {
            this.Validate(type);

            this.Type = type;
            this.Trainer = trainer;
        }

        public string Type { get; private set; }

        public Trainer Trainer { get; private set; }

        private void Validate(string type)
        {
            this.ValidateType(type);
        }

        private void ValidateType(string type)
            => Guard.AgainstEmptyString<InvalidTrainingException>(
                type,
                nameof(type));
    }
}
