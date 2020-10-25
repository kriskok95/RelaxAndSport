namespace RelaxAndSport.Domain.Booking.Factories.TrainingsSchedule
{
    using RelaxAndSport.Domain.Booking.Models.TrainingsSchedule;

    public class TrainingsScheduleFactory : ITrainingsScheduleFactory
    {
        public TrainingsSchedule Build()
            => new TrainingsSchedule();
    }
}
