namespace RelaxAndSport.Application.Statistics.Handlers
{
    using RelaxAndSport.Application.Common;
    using RelaxAndSport.Domain.Booking.Events;
    using RelaxAndSport.Domain.Statistics.Repositories;
    using System.Threading.Tasks;

    public class MassageAppointmentRemovedEventHandler : IEventHandler<MassageAppointmentRemovedEvent>
    {
        private readonly IStatisticsDomainRepository statisticsRepository;

        public MassageAppointmentRemovedEventHandler(IStatisticsDomainRepository statisticsRepository)
            => this.statisticsRepository = statisticsRepository;

        public async Task Handle(MassageAppointmentRemovedEvent domainEvent)
            => await this.statisticsRepository.DecrementMassageAppointments();
    }
}
