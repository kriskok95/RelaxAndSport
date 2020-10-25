namespace RelaxAndSport.Application.Booking.TrainingsAppointments.Queries.GetByDate
{
    using MediatR;
    using RelaxAndSport.Application.Booking.TrainingsAppointments.Queries.Common;
    using RelaxAndSport.Application.Common;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetTrainingsAppointmentsByDateQuery : EntityCommand<int>, IRequest<IEnumerable<TrainingAppointmentOutputModel>>
    {
        public DateTime Date { get; set; }

        public class GetTrainingsAppointmentsByDateQueryHandler : IRequestHandler<GetTrainingsAppointmentsByDateQuery, IEnumerable<TrainingAppointmentOutputModel>>
        {
            private readonly ITrainingsAppointmentsQueryRepository trainingsAppointmentsRepository;

            public GetTrainingsAppointmentsByDateQueryHandler(
                ITrainingsAppointmentsQueryRepository trainingsAppointmentsRepository)
            {
                this.trainingsAppointmentsRepository = trainingsAppointmentsRepository;
            }

            public async Task<IEnumerable<TrainingAppointmentOutputModel>> Handle(GetTrainingsAppointmentsByDateQuery request, CancellationToken cancellationToken)
                => await this
                .trainingsAppointmentsRepository
                .GetByDate(request.Date);
        }
    }
}
