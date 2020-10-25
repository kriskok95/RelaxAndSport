namespace RelaxAndSport.Application.Booking.TrainingsAppointments.Commands.Common
{
    using RelaxAndSport.Application.Common;
    using System;

    public class TrainingAppointmentCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public int TrainingId { get; set; }

        public DateTime StartDate { get; set; } = default!;
    }
}
