namespace RelaxAndSport.Application.Booking.Trainings.Commands.Create
{
    using MediatR;
    using RelaxAndSport.Application.Booking.Trainings.Commands.Common;
    using RelaxAndSport.Domain.Booking.Factories.Trainings;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateTrainingCommand : TrainingCommand<CreateTrainingCommand>, IRequest<CreateTrainingOutputModel>
    {
        public class CreateTrainingCommandHandler : IRequestHandler<CreateTrainingCommand, CreateTrainingOutputModel>
        {
            private readonly ITrainingsRepository trainingsRepository;
            private readonly ITrainingsFactory trainingsFactory;

            public CreateTrainingCommandHandler(
                ITrainingsRepository trainingsRepository,
                ITrainingsFactory trainingsFactory)
            {
                this.trainingsRepository = trainingsRepository;
                this.trainingsFactory = trainingsFactory;
            }

            public async Task<CreateTrainingOutputModel> Handle(CreateTrainingCommand request, CancellationToken cancellationToken)
            {
                var training = this.trainingsFactory
                    .WithType(request.Type)
                    .WithTrainer(request.TrainerFirstName, request.TrainerLastName)
                    .WithDate(request.Date)
                    .WithDuration(request.Duration)
                    .WithSlots(request.Slots)
                    .WithPrice(request.Price)
                    .WithIsRepeated(request.IsRepeated)
                    .Build();

                await this.trainingsRepository.Save(training, cancellationToken);

                return new CreateTrainingOutputModel(training.Id);
            }
        }
    }
}
