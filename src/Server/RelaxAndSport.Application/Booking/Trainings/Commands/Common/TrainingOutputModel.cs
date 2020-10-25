namespace RelaxAndSport.Application.Booking.Trainings.Commands.Common
{
    using AutoMapper;
    using RelaxAndSport.Application.Common.Mapping;
    using RelaxAndSport.Domain.Booking.Models.Trainings;
    using System;

    public class TrainingOutputModel : IMapFrom<Training>
    {
        public string Category { get; set; } = default!;

        public string Trainer { get; set; } = default!;

        public DateTime StartAt { get; set; }

        public int Duration { get; set; }

        public int Slots { get; set; }

        public decimal Price { get; set; }

        public bool IsRepeated { get; set; }

        public void Mapping(Profile mapper)
            => mapper
            .CreateMap<Training, TrainingOutputModel>()
            .ForMember(t => t.Trainer, cfg => cfg
                .MapFrom(s => $"{s.Trainer.FirstName} {s.Trainer.LastName}"))
            .ForMember(t => t.StartAt, cfg => cfg
                .MapFrom(s => s.Date));
    }
}
