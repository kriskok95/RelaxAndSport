namespace RelaxAndSport.Application.Booking.TrainingsAppointments.Commands.Create
{
    using MediatR;
    using RelaxAndSport.Application.Booking.TrainingsAppointments.Commands.Common;
    using RelaxAndSport.Application.Booking.TrainingsSchedule;
    using RelaxAndSport.Application.Common.Contracts;
    using RelaxAndSport.Domain.Booking.Factories.TrainingsAppointmentsFactory;
    using RelaxAndSport.Domain.Booking.Repositories;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateTrainingAppointmentCommand : TrainingAppointmentCommand<CreateTrainingAppointmentCommand>, IRequest<CreateTrainingAppointmentOutputModel>
    {
        public class CreateTrainingAppointmentCommandHandler : IRequestHandler<CreateTrainingAppointmentCommand, CreateTrainingAppointmentOutputModel>
        {
            private readonly IClientDomainRepository clientRepository;
            private readonly ICurrentUser currentUser;
            private readonly ITrainingsScheduleDomainRepository trainingsScheduleRepository;
            private readonly ITrainingsDomainRepository trainingsRepository;
            private readonly ITrainingsAppointmentsFactory trainingsAppointmentsFactory;
            private readonly ITrainingsAppointmentsDomainRepository trainingsAppointmentsRepository;

            public CreateTrainingAppointmentCommandHandler(
                IClientDomainRepository clientRepository,
                ICurrentUser currentUser,
                ITrainingsScheduleDomainRepository trainingsScheduleRepository,
                ITrainingsDomainRepository trainingsRepository,
                ITrainingsAppointmentsFactory trainingsAppointmentsFactory,
                ITrainingsAppointmentsDomainRepository trainingsAppointmentsRepository)
            {
                this.clientRepository = clientRepository;
                this.currentUser = currentUser;
                this.trainingsScheduleRepository = trainingsScheduleRepository;
                this.trainingsRepository = trainingsRepository;
                this.trainingsAppointmentsFactory = trainingsAppointmentsFactory;
                this.trainingsAppointmentsRepository = trainingsAppointmentsRepository;
            }

            public async Task<CreateTrainingAppointmentOutputModel> Handle(CreateTrainingAppointmentCommand request, CancellationToken cancellationToken)
            {
                var client = await this.clientRepository
                    .FindByUser(this.currentUser.UserId, cancellationToken);

                var trainingsSchedule = await this.trainingsScheduleRepository
                    .GetTrainingsSchedule(cancellationToken);

                var training = await this.trainingsRepository
                    .Find(request.TrainingId, cancellationToken);

                var trainingAppointment = this.trainingsAppointmentsFactory
                    .WithTraining(training)
                    .WithTimeRange(request.StartDate, training.Duration)
                    .Build();

                trainingsSchedule.AddTrainingAppointment(trainingAppointment);
                client.AddTrainingAppointment(trainingAppointment);

                await this.trainingsAppointmentsRepository.Save(trainingAppointment, cancellationToken);

                return new CreateTrainingAppointmentOutputModel(trainingAppointment.Id);
            }
        }
    }
}
