namespace RelaxAndSport.Application.Booking.Trainings.Commands.Edit
{
    using MediatR;
    using RelaxAndSport.Application.Booking.Trainings.Commands.Common;
    using RelaxAndSport.Application.Common;
    using RelaxAndSport.Domain.Booking.Factories.Trainings;
    using RelaxAndSport.Domain.Booking.Repositories;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditTrainingCommand : TrainingCommand<EditTrainingCommand>, IRequest<Result>
    {
        public class EditTrainingCommandHandler : IRequestHandler<EditTrainingCommand, Result>
        {
            private readonly ITrainingsDomainRepository trainingsRepository;
            private readonly ITrainingsFactory trainingsFactory;

            public EditTrainingCommandHandler(
                ITrainingsDomainRepository trainingsRepository,
                ITrainingsFactory trainingsFactory)
            {
                this.trainingsRepository = trainingsRepository;
                this.trainingsFactory = trainingsFactory;
            }

            public async Task<Result> Handle(EditTrainingCommand request, CancellationToken cancellationToken)
            {
                var training = await this.trainingsRepository
                    .GetById(request.Id);

                if(training == null)
                {
                    return $"Training with Id: {request.Id} doesn't exists.";
                }

                var trainer = await this.trainingsRepository
                    .GetTrainer(request.TrainerFirstName, request.TrainerLastName, cancellationToken);

                if(trainer == null)
                {
                    trainer = this.trainingsFactory
                        .WithTrainer(request.TrainerFirstName, request.TrainerLastName)
                        .BuildTrainer();
                }

                training
                    .UpdateCategory(request.Category)
                    .UpdateTrainer(trainer)
                    .UpdateDate(request.Date)
                    .UpdateDuration(request.Duration)
                    .UpdateSlots(request.Slots)
                    .UpdatePrice(request.Price)
                    .UpdateIsRepeated(request.IsRepeated);

                await this.trainingsRepository
                    .Save(training, cancellationToken);

                return Result.Success;
            }
        }
    }
}
