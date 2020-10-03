namespace RelaxAndSport.Domain.Booking.Factories.TrainingsSchedule
{
    using RelaxAndSport.Domain.Booking.Models.TrainingSchedule;

    public class TrainingsScheduleFactory : ITrainingsScheduleFactory
    {
        public TrainingsSchedule Build()
            => new TrainingsSchedule();
    }
}
