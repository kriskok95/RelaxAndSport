namespace RelaxAndSport.Application.Booking.TrainingsAppointments.Commands.Delete
{
    using MediatR;
    using RelaxAndSport.Application.Common;
    using RelaxAndSport.Application.Common.Contracts;
    using RelaxAndSport.Domain.Booking.Repositories;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteTrainingAppointmentCommand : EntityCommand<int>, IRequest<Result>
    {
        public int Id { get; set; }

        public class DeleteTrainingAppointmentCommandHandler : IRequestHandler<DeleteTrainingAppointmentCommand, Result>
        {
            private readonly ITrainingsScheduleDomainRepository trainingsScheduleRepository;
            private readonly ITrainingsAppointmentsDomainRepository trainingsAppointmentsRepository;
            private readonly IClientDomainRepository clientRepository;
            private readonly ICurrentUser currentUser;

            public DeleteTrainingAppointmentCommandHandler(
                ITrainingsScheduleDomainRepository trainingsScheduleRepository,
                ITrainingsAppointmentsDomainRepository trainingsAppointmentsRepository,
                IClientDomainRepository clientRepository,
                ICurrentUser currentUser)
            {
                this.trainingsScheduleRepository = trainingsScheduleRepository;
                this.trainingsAppointmentsRepository = trainingsAppointmentsRepository;
                this.clientRepository = clientRepository;
                this.currentUser = currentUser;
            }

            public async Task<Result> Handle(DeleteTrainingAppointmentCommand request, CancellationToken cancellationToken)
            {
                var client = await this.clientRepository
                   .FindByUser(this.currentUser.UserId, cancellationToken);

                var trainingsSchedule = await this.trainingsScheduleRepository
                    .GetTrainingsSchedule();

                var trainingAppointment = await this.trainingsAppointmentsRepository
                    .GetTrainingAppointment(request.Id, cancellationToken);

                client.RemoveTrainingAppointment(trainingAppointment);
                trainingsSchedule.RemoveTrainingAppointment(trainingAppointment);

                await this.trainingsAppointmentsRepository.Delete(trainingAppointment, cancellationToken);

                return Result.Success;
            }
        }
    }
}
