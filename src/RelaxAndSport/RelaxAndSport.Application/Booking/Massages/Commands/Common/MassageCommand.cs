namespace RelaxAndSport.Application.Booking.Massages.Commands.Common
{
    using RelaxAndSport.Application.Common;

    public abstract class MassageCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string Category { get; set; } = default!;

        public string Description { get; set; } = default!;

        public decimal Price { get; set; }

        public int Duration { get; set; }
    }
}
