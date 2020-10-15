namespace RelaxAndSport.Application.Booking.Trainings.Queries.Details
{
    using MediatR;
    using RelaxAndSport.Application.Booking.Trainings.Commands.Common;
    using RelaxAndSport.Application.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class TrainingDetailsQuery : EntityCommand<int>, IRequest<TrainingOutputModel>
    {
        public class TrainingDetailsQueryHandler : IRequestHandler<TrainingDetailsQuery, TrainingOutputModel>
        {
            private readonly ITrainingsRepository trainingsRepository;

            public TrainingDetailsQueryHandler(
                ITrainingsRepository trainingsRepository)
            {
                this.trainingsRepository = trainingsRepository;
            }

            public async Task<TrainingOutputModel> Handle(TrainingDetailsQuery request, CancellationToken cancellationToken)
               => await this.trainingsRepository
                    .GetTrainingOutputModelById(request.Id, cancellationToken);
        }
    }
}
