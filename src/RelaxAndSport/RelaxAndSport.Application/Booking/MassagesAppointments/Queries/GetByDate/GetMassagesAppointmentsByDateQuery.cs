namespace RelaxAndSport.Application.Booking.MassagesAppointments.Queries.GetByDate
{
    using MediatR;
    using RelaxAndSport.Application.Booking.MassagesAppointments.Queries.Common;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetMassagesAppointmentsByDateQuery : IRequest<IEnumerable<MassageAppointmentOutputModel>>
    {
        public DateTime Date { get; set; }

        public class GetMassagesAppointmentsByDateQueryHandler : IRequestHandler<GetMassagesAppointmentsByDateQuery, IEnumerable<MassageAppointmentOutputModel>>
        {
            private readonly IMassagesAppointmentsRepository massagesAppointmentsRepository;

            public GetMassagesAppointmentsByDateQueryHandler(
                IMassagesAppointmentsRepository massagesAppointmentsRepository)
            {
                this.massagesAppointmentsRepository = massagesAppointmentsRepository;
            }

            public async Task<IEnumerable<MassageAppointmentOutputModel>> Handle(GetMassagesAppointmentsByDateQuery request, CancellationToken cancellationToken)
                => await this.massagesAppointmentsRepository
                    .GetByDate(request.Date);
        }
    }
}
