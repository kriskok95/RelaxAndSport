namespace RelaxAndSport.Application.Booking.Massages.Queries.Common
{
    using RelaxAndSport.Application.Common.Mapping;
    using RelaxAndSport.Domain.Booking.Models.Massages;

    public class MassageOutputModel : IMapFrom<Massage>
    {
        public int Id { get; set; }

        public string Category { get; set; } = default!;

        public string Description { get; set; } = default!;

        public decimal Price { get; set; }

        public int Duration { get; set; }
    }
}
