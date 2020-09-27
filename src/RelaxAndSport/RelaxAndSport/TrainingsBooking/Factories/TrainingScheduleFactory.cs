namespace RelaxAndSport.Domain.TrainingsBooking.Factories
{
    using RelaxAndSport.Domain.TrainingsBooking.Models.TrainingSchedule;

    public class TrainingScheduleFactory : ITrainingsScheduleFactory
    {
        public TrainingSchedule Build()
            => new TrainingSchedule();
    }
}
