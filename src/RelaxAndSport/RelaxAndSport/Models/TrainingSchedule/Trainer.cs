namespace RelaxAndSport.Domain.Models.TrainingSchedule
{
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.Exceptions;

    using static ModelConstants.Common;

    public class Trainer : Entity<int>
    {
        internal Trainer(
            string firstName,
            string lastName)
        {
            Validate(firstName, lastName);

            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        private void Validate(string firstName, string lastName)
        {
            ValidateFirstName(firstName);
            ValidateLastName(lastName);
        }

        private void ValidateFirstName(string firstName)
            => Guard.ForStringLength<InvalidTrainingException>(
                firstName,
                MinNameLength,
                MaxNameLength,
                nameof(firstName));

        private void ValidateLastName(string lastName)
            => Guard.ForStringLength<InvalidTrainingException>(
                lastName,
                MinNameLength,
                MaxNameLength,
                nameof(lastName));
    }
}
