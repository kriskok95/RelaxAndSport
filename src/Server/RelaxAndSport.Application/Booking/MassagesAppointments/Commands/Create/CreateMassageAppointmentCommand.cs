namespace RelaxAndSport.Application.Booking.MassagesAppointments.Commands.Create
{
    using MediatR;
    using RelaxAndSport.Application.Booking.MassagesAppointments.Commands.Common;
    using RelaxAndSport.Application.Booking.MassagesAppointments.Commands.CreateMassageAppointment;
    using RelaxAndSport.Application.Common.Contracts;
    using RelaxAndSport.Domain.Booking.Factories.MassagesAppointments;
    using RelaxAndSport.Domain.Booking.Repositories;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateMassageAppointmentCommand : MassageAppointmentCommand<CreateMassageAppointmentCommand>, IRequest<CreateMassageAppointmentOutputModel>
    {
        public class CraeteMassageAppointmentCommandHandler : IRequestHandler<CreateMassageAppointmentCommand, CreateMassageAppointmentOutputModel>
        {
            private readonly ICurrentUser currentUser;
            private readonly IClientDomainRepository clientRepository;
            private readonly IMassagesScheduleDomainRepository massagesScheduleRepository;
            private readonly IMassagesDomainRepository massagesRepository;
            private readonly IMassagesAppointmentsFactory massagesAppointmentsFactory;
            private readonly IMassagesAppointmentsDomainRepository massagesAppointmentsRepository;

            public CraeteMassageAppointmentCommandHandler(
                ICurrentUser currentUser,
                IClientDomainRepository clientRepository,
                IMassagesScheduleDomainRepository massagesScheduleRepository,
                IMassagesDomainRepository massagesRepository,
                IMassagesAppointmentsFactory massagesAppointmentsFactory,
                IMassagesAppointmentsDomainRepository massagesAppointmentsRepository)
            {
                this.currentUser = currentUser;
                this.clientRepository = clientRepository;
                this.massagesScheduleRepository = massagesScheduleRepository;
                this.massagesRepository = massagesRepository;
                this.massagesAppointmentsFactory = massagesAppointmentsFactory;
                this.massagesAppointmentsRepository = massagesAppointmentsRepository;
            }

            public async Task<CreateMassageAppointmentOutputModel> Handle(CreateMassageAppointmentCommand request, CancellationToken cancellationToken)
            {
                var client = await this.clientRepository
                    .FindByUser(this.currentUser.UserId, cancellationToken);

                var massagesSchedule = await massagesScheduleRepository
                    .GetMassagesSchedule();

                var massage = await this.massagesRepository
                    .Find(request.MassageId, cancellationToken);

                var massageAppointment = this.massagesAppointmentsFactory
                    .WithMassage(massage)
                    .WithTimeRange(request.StartDate, massage.Duration)
                    .Build();

                massagesSchedule.AddMassageAppointment(massageAppointment);
                client.AddMassageAppointment(massageAppointment);

                await this.massagesAppointmentsRepository.Save(massageAppointment, cancellationToken);

                return new CreateMassageAppointmentOutputModel(massageAppointment.Id);
            }
        }
    }
}
