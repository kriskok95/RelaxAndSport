namespace RelaxAndSport.Domain.MassagesBooking.Factories.MassagesSchedule
{
    using RelaxAndSport.Domain.MassagesBooking.Models.MassagesSchedule;

    public class MassagesScheduleFactory : IMassagesScheduleFactory
    {
        public MassagesSchedule Build()
            => new MassagesSchedule();
    }
}
