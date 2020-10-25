namespace RelaxAndSport.Application.Statistics.Handlers
{
    using RelaxAndSport.Application.Common;
    using RelaxAndSport.Domain.Booking.Events;
    using RelaxAndSport.Domain.Statistics.Repositories;
    using System.Threading.Tasks;

    public class TrainingAppointmentAddedEventHandler : IEventHandler<TrainingAppointmentAddedEvent>
    {
        private readonly IStatisticsDomainRepository statisticsRepository;

        public TrainingAppointmentAddedEventHandler(IStatisticsDomainRepository statisticsRepository)
            => this.statisticsRepository = statisticsRepository;

        public async Task Handle(TrainingAppointmentAddedEvent domainEvent)
            => await this.statisticsRepository.IncrementTrainingsAppointments();    
    }
}
