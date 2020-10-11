namespace RelaxAndSport.Domain.Booking.Factories.MassagesSchedule
{
    using RelaxAndSport.Domain.Booking.Models.MassagesSchedule;

    public class MassagesScheduleFactory : IMassagesScheduleFactory
    {
        public MassagesSchedule Build()
            => new MassagesSchedule();


    }
}
