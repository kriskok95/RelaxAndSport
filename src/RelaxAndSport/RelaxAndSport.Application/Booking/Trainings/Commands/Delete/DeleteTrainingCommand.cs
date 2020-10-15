namespace RelaxAndSport.Application.Booking.Trainings.Commands.Delete
{
    using MediatR;
    using RelaxAndSport.Application.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteTrainingCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteTrainingCommandHandler : IRequestHandler<DeleteTrainingCommand, Result>
        {
            private readonly ITrainingsRepository trainingsRepository;

            public DeleteTrainingCommandHandler(
                ITrainingsRepository trainingsRepository)
            {
                this.trainingsRepository = trainingsRepository;
            }

            public async Task<Result> Handle(DeleteTrainingCommand request, CancellationToken cancellationToken)
                => await this.trainingsRepository.Delete(request.Id, cancellationToken);
        }
    }
}
