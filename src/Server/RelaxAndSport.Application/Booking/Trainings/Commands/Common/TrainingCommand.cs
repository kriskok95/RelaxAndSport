namespace RelaxAndSport.Application.Booking.Trainings.Commands.Common
{
    using RelaxAndSport.Application.Common;
    using System;

    public class TrainingCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string Category { get; set; } = default!;

        public string TrainerFirstName { get; set; } = default!;

        public string TrainerLastName { get; set; } = default!;

        public DateTime Date { get; set; }

        public int Duration { get; set; }

        public int Slots { get; set; }

        public decimal Price { get; set; }

        public bool IsRepeated { get; set; }
    }
}
