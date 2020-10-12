namespace RelaxAndSport.Application.Booking.MassagesAppointments.Commands.DeleteMassageAppointment
{
    using MediatR;
    using RelaxAndSport.Application.Booking.Client;
    using RelaxAndSport.Application.Booking.Massages.Commands.Delete;
    using RelaxAndSport.Application.Booking.MassagesSchedule;
    using RelaxAndSport.Application.Common;
    using RelaxAndSport.Application.Common.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteMassageAppointmentComand : EntityCommand<int>, IRequest<Result>
    {
        public int Id { get; set; }

        public class DeleteMassageAppointmentCommandHandler : IRequestHandler<DeleteMassageAppointmentComand, Result>
        {
            IMassagesScheduleRepository massagesScheduleRepository;
            IMassagesAppointmentsRepository massagesAppointmentsRepository;
            ICurrentUser currentUser;
            IClientRepository clientRepository;

            public DeleteMassageAppointmentCommandHandler(
                IMassagesScheduleRepository massagesScheduleRepository,
                IMassagesAppointmentsRepository massagesAppointmentsRepository,
                ICurrentUser currentUser,
                IClientRepository clientRepository)
            {
                this.massagesScheduleRepository = massagesScheduleRepository;
                this.massagesAppointmentsRepository = massagesAppointmentsRepository;
                this.currentUser = currentUser;
                this.clientRepository = clientRepository;
            }

            public async Task<Result> Handle(DeleteMassageAppointmentComand request, CancellationToken cancellationToken)
            {
                var client = await this.clientRepository
                    .FindByUser(this.currentUser.UserId, cancellationToken);

                var massagesSchedule = await massagesScheduleRepository
                    .GetMassagesSchedule();

                var massageAppointment = await this.massagesAppointmentsRepository
                    .GetMassageAppointment(request.Id);

                client.RemoveMassageAppointment(massageAppointment);
                massagesSchedule.RemoveMassageAppointment(massageAppointment);

                await this.massagesAppointmentsRepository.Delete(massageAppointment, cancellationToken);

                return Result.Success;
            }
        }
    }
}
