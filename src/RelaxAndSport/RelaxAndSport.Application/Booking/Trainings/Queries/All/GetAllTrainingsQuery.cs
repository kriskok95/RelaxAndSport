namespace RelaxAndSport.Application.Booking.Trainings.Queries.All
{
    using MediatR;
    using RelaxAndSport.Application.Booking.Trainings.Commands.Common;
    using RelaxAndSport.Application.Common;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllTrainingsQuery : EntityCommand<int>, IRequest<IEnumerable<TrainingOutputModel>>
    {
        public class GetAllTrainingsQueryHandler : IRequestHandler<GetAllTrainingsQuery, IEnumerable<TrainingOutputModel>>
        {
            private readonly ITrainingsRepository trainingsRepository;

            public GetAllTrainingsQueryHandler(
                ITrainingsRepository trainingsRepository)
            {
                this.trainingsRepository = trainingsRepository;
            }

            public async Task<IEnumerable<TrainingOutputModel>> Handle(GetAllTrainingsQuery request, CancellationToken cancellationToken)
                => await this
                .trainingsRepository
                .GetAll();
        }
    }
}
