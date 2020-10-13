namespace RelaxAndSport.Application.Statistics.Handlers
{
    using RelaxAndSport.Application.Common;
    using RelaxAndSport.Domain.Booking.Events;
    using System.Threading.Tasks;

    public class MassageAppointmentAddedEventHandler : IEventHandler<MassageAppointmentAddedEvent>
    {
        private readonly IStatisticsRepository statisticsRepository;

        public MassageAppointmentAddedEventHandler(IStatisticsRepository statisticsRepository)
            => this.statisticsRepository = statisticsRepository;
        

        public Task Handle(MassageAppointmentAddedEvent domainEvent)
            => this.statisticsRepository.IncrementMassagesAppointments();
    }
}
