namespace RelaxAndSport.Application.Booking.TrainingsAppointments.Commands.Edit
{
    using MediatR;
    using RelaxAndSport.Application.Common;
    using RelaxAndSport.Domain.Booking.Repositories;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditTrainingAppointmentCommand : EntityCommand<int>, IRequest<Result>
    {
        public int TrainingId { get; set; }

        public DateTime StartDate { get; set; }

        public class EditTrainingAppointmentCommandHandler : IRequestHandler<EditTrainingAppointmentCommand, Result>
        {
            private readonly ITrainingsAppointmentsDomainRepository trainingAppointmentsRepository;
            private readonly ITrainingsDomainRepository trainingsRepository;

            public EditTrainingAppointmentCommandHandler(
                ITrainingsAppointmentsDomainRepository trainingAppointmentsRepository,
                ITrainingsDomainRepository trainingsRepository)
            {
                this.trainingAppointmentsRepository = trainingAppointmentsRepository;
                this.trainingsRepository = trainingsRepository;
            }

            public async Task<Result> Handle(EditTrainingAppointmentCommand request, CancellationToken cancellationToken)
            {
                var trainingAppointment = await this.trainingAppointmentsRepository
                    .GetTrainingAppointment(request.Id, cancellationToken);

                var training = await this.trainingsRepository
                    .Find(request.TrainingId, cancellationToken);

                trainingAppointment
                    .UpdateTraining(training)
                    .UpdateTimeRange(request.StartDate);

                await this.trainingAppointmentsRepository.Save(trainingAppointment, cancellationToken);

                return Result.Success;
            }
        }
    }
}
