namespace RelaxAndSport.Application.Booking.MassagesAppointments.Commands.Common
{
    using RelaxAndSport.Application.Common;
    using System;

    public abstract class MassageAppointmentCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public int MassageId { get; set; }

        public DateTime StartDate { get; set; } = default!;
    }
}
