namespace RelaxAndSport.Application.Statistics.Handlers
{
    using RelaxAndSport.Application.Common;
    using RelaxAndSport.Domain.Booking.Events;
    using RelaxAndSport.Domain.Statistics.Repositories;
    using System.Threading.Tasks;

    public class TrainingAppointmentRemovedEventHandler : IEventHandler<TrainingAppointmentRemovedEvent>
    {
        private readonly IStatisticsDomainRepository statisticsRepository;

        public TrainingAppointmentRemovedEventHandler(IStatisticsDomainRepository statisticsRepository)
            => this.statisticsRepository = statisticsRepository;

        public async Task Handle(TrainingAppointmentRemovedEvent domainEvent)
            => await this.statisticsRepository.DecrementTrainingAppointments();
    }
}
