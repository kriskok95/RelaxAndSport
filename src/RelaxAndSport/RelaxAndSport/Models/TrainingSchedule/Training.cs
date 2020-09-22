namespace RelaxAndSport.Domain.Models.TrainingSchedule
{
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.Exceptions;

    public class Training : Entity<int>
    {
        internal Training(
            string type,
            Trainer trainer)
        {
            Validate(type);

            Type = type;
            Trainer = trainer;
        }

        public string Type { get; private set; }

        public Trainer Trainer { get; private set; }

        private void Validate(string type)
        {
            ValidateType(type);
        }

        private void ValidateType(string type)
            => Guard.AgainstEmptyString<InvalidTrainingException>(
                type,
                nameof(type));
    }
}
