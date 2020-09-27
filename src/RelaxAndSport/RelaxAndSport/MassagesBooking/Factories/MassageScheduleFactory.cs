namespace RelaxAndSport.Domain.MassagesBooking.Factories
{
    using RelaxAndSport.Domain.MassagesBooking.Models.MassagesSchedule;
    public class MassageScheduleFactory : IMassagesScheduleFactory
    {
        public MassagesSchedule Build()
            => new MassagesSchedule();
    }
}
