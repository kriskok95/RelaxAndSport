namespace RelaxAndSport.Application.Booking.Trainings.Commands.Create
{
    using MediatR;
    using RelaxAndSport.Application.Booking.Trainings.Commands.Common;
    using RelaxAndSport.Domain.Booking.Factories.Trainings;
    using RelaxAndSport.Domain.Booking.Repositories;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateTrainingCommand : TrainingCommand<CreateTrainingCommand>, IRequest<CreateTrainingOutputModel>
    {
        public class CreateTrainingCommandHandler : IRequestHandler<CreateTrainingCommand, CreateTrainingOutputModel>
        {
            private readonly ITrainingsDomainRepository trainingsRepository;
            private readonly ITrainingsFactory trainingsFactory;

            public CreateTrainingCommandHandler(
                ITrainingsDomainRepository trainingsRepository,
                ITrainingsFactory trainingsFactory)
            {
                this.trainingsRepository = trainingsRepository;
                this.trainingsFactory = trainingsFactory;
            }

            public async Task<CreateTrainingOutputModel> Handle(CreateTrainingCommand request, CancellationToken cancellationToken)
            {
                var trainer = await this.trainingsRepository
                    .GetTrainer(request.TrainerFirstName, request.TrainerLastName, cancellationToken);

                if(trainer == null)
                {
                    trainer = this.trainingsFactory
                        .WithTrainer(request.TrainerFirstName, request.TrainerLastName)
                        .BuildTrainer();
                }

                var training = this.trainingsFactory
                    .WithCategory(request.Category)
                    .WithDate(request.Date)
                    .WithTrainer(trainer)
                    .WithDuration(request.Duration)
                    .WithSlots(request.Slots)
                    .WithPrice(request.Price)
                    .WithIsRepeated(request.IsRepeated)
                    .Build();

                await this.trainingsRepository.ValidateTrainingExistence(training, cancellationToken);
                await this.trainingsRepository.Save(training, cancellationToken);

                return new CreateTrainingOutputModel(training.Id);
            }
        }
    }
}
