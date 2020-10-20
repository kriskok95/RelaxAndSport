namespace RelaxAndSport.Application.Statistics.Handlers
{
    using RelaxAndSport.Application.Common;
    using RelaxAndSport.Domain.Booking.Events;
    using RelaxAndSport.Domain.Statistics.Repositories;
    using System.Threading.Tasks;

    public class MassageAppointmentAddedEventHandler : IEventHandler<MassageAppointmentAddedEvent>
    {
        private readonly IStatisticsDomainRepository statisticsRepository;

        public MassageAppointmentAddedEventHandler(IStatisticsDomainRepository statisticsRepository)
            => this.statisticsRepository = statisticsRepository;

        public Task Handle(MassageAppointmentAddedEvent domainEvent)
            => this.statisticsRepository.IncrementMassagesAppointments();
    }
}
