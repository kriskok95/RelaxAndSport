namespace RelaxAndSport.Domain.MassagesBooking.Models.MassagesSchedule
{
    using RelaxAndSport.Domain.Common;
    using RelaxAndSport.Domain.MassagesBooking.Exceptions;

    using static RelaxAndSport.Domain.Common.Models.ModelConstants.Massage;

    public class Massage : Entity<int>
    {
        internal Massage(
            Type type,
            int duration,
            string description)
        {
            Validate(duration);

            Type = type;
            Description = description;
        }

        public Type Type { get; private set; }

        public string Description { get; private set; }

        private void Validate(int duration)
        {
            ValidateDuration(duration);
        }

        private void ValidateDuration(int duration)
            => Guard.AgainstOutOfRange<InvalidMassageException>(
                duration,
                MinDuration,
                MaxDuration,
                nameof(duration));
    }
}
