namespace RelaxAndSport.Application.Booking.TrainingsAppointments.Queries.Common
{
    using AutoMapper;
    using RelaxAndSport.Application.Common.Mapping;
    using RelaxAndSport.Domain.Booking.Models.TrainifngsAppointments;
    using RelaxAndSport.Domain.Common.Models;

    public class TrainingAppointmentOutputModel : IMapFrom<TrainingAppointment>
    {
        public DateTimeRange TimeRange { get; set; } = default!;

        public string TrainingCategory { get; set; } = default!;

        public void Mapping(Profile mapper)
            => mapper
            .CreateMap<TrainingAppointment, TrainingAppointmentOutputModel>()
            .ForMember(ta => ta.TrainingCategory, cfg => cfg
                .MapFrom(s => s.Training.Category));
    }
}
