namespace RelaxAndSport.Application.Booking.MassagesAppointments.Commands.CreateMassageAppointment
{
    public class CreateMassageAppointmentOutputModel
    {
        public CreateMassageAppointmentOutputModel(int appointmentId)
            => this.AppointmentId = appointmentId;

        public int AppointmentId { get; set; }
    }
}
