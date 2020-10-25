namespace RelaxAndSport.Domain.Booking.Exceptions
{
    using RelaxAndSport.Domain.Common.Exceptions;

    public class InvalidMassageAppointmentException : BaseDomainException
    {
        public InvalidMassageAppointmentException()
        {

        }

        public InvalidMassageAppointmentException(string error) => this.Error = error;
    }
}
