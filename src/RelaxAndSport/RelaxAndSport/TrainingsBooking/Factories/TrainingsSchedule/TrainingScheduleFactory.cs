namespace RelaxAndSport.Domain.TrainingsBooking.Factories.TrainingsSchedule
{
    using RelaxAndSport.Domain.TrainingsBooking.Models.TrainingSchedule;

    public class TrainingScheduleFactory : ITrainingsScheduleFactory
    {
        public TrainingsSchedule Build()
            => new TrainingsSchedule();
    }
}
