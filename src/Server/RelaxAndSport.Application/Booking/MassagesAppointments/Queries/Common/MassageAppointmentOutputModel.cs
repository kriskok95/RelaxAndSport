namespace RelaxAndSport.Application.Booking.MassagesAppointments.Queries.Common
{
    using AutoMapper;
    using RelaxAndSport.Application.Common.Mapping;
    using RelaxAndSport.Domain.Booking.Models.MassagesAppointments;
    using RelaxAndSport.Domain.Common.Models;

    public class MassageAppointmentOutputModel : IMapFrom<MassageAppointment>
    {
        public DateTimeRange TimeRange { get; set; } = default!;

        public string MassageCategory { get; set; } = default!;

        public void Mapping(Profile mapper)
            => mapper
            .CreateMap<MassageAppointment, MassageAppointmentOutputModel>()
            .ForMember(ma => ma.MassageCategory, cfg => cfg
                .MapFrom(s => s.Massage.Category));
    }
}
