namespace RelaxAndSport.Application.Booking.MassagesAppointments.Commands.DeleteMassageAppointment
{
    using MediatR;
    using RelaxAndSport.Application.Common;
    using RelaxAndSport.Application.Common.Contracts;
    using RelaxAndSport.Domain.Booking.Repositories;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteMassageAppointmentComand : EntityCommand<int>, IRequest<Result>
    {
        public int Id { get; set; }

        public class DeleteMassageAppointmentCommandHandler : IRequestHandler<DeleteMassageAppointmentComand, Result>
        {
            IMassagesScheduleDomainRepository massagesScheduleRepository;
            IMassagesAppointmentsDomainRepository massagesAppointmentsRepository;
            ICurrentUser currentUser;
            IClientDomainRepository clientRepository;

            public DeleteMassageAppointmentCommandHandler(
                IMassagesScheduleDomainRepository massagesScheduleRepository,
                IMassagesAppointmentsDomainRepository massagesAppointmentsRepository,
                ICurrentUser currentUser,
                IClientDomainRepository clientRepository)
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
