
namespace RelaxAndSport.Application.Booking.MassagesAppointments.Commands.Edit
{
    using MediatR;
    using RelaxAndSport.Application.Booking.Massages;
    using RelaxAndSport.Application.Common;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditMassageAppointmentCommand : EntityCommand<int>, IRequest<Result>
    {
        public int MassageId { get; set; }

        public DateTime StartDate { get; set; }

        public class EditMassageAppointmentCommandHandler : IRequestHandler<EditMassageAppointmentCommand, Result>
        {
            private readonly IMassagesAppointmentsRepository massagesAppointmentsRepository;
            private readonly IMassagesRepository massagesRepository;

            public EditMassageAppointmentCommandHandler(
                IMassagesAppointmentsRepository massagesAppointmentsRepository,
                IMassagesRepository massagesRepository)
            {
                this.massagesAppointmentsRepository = massagesAppointmentsRepository;
                this.massagesRepository = massagesRepository;
            }

            public async Task<Result> Handle(EditMassageAppointmentCommand request, CancellationToken cancellationToken)
            {
                var massageAppointment = await this.massagesAppointmentsRepository
                    .GetMassageAppointment(request.Id);

                var massage = await this.massagesRepository
                    .Find(request.MassageId, cancellationToken);

                massageAppointment
                    .UpdateMassage(massage)
                    .UpdateTimeRange(request.StartDate);

                await this.massagesAppointmentsRepository.Save(massageAppointment, cancellationToken);

                return Result.Success;
            }
        }
    }
}
