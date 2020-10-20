namespace RelaxAndSport.Application.Booking.Trainings.Commands.Delete
{
    using MediatR;
    using RelaxAndSport.Application.Common;
    using RelaxAndSport.Domain.Booking.Repositories;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteTrainingCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteTrainingCommandHandler : IRequestHandler<DeleteTrainingCommand, Result>
        {
            private readonly ITrainingsDomainRepository trainingsRepository;

            public DeleteTrainingCommandHandler(
                ITrainingsDomainRepository trainingsRepository)
            {
                this.trainingsRepository = trainingsRepository;
            }

            public async Task<Result> Handle(DeleteTrainingCommand request, CancellationToken cancellationToken)
                => await this.trainingsRepository.Delete(request.Id, cancellationToken);
        }
    }
}
