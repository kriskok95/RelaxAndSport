namespace RelaxAndSport.Domain.MassagesBooking.Exceptions
{
    using RelaxAndSport.Domain.Common.Exceptions;

    public class IvalidMassageAppointmentException : BaseDomainException
    {
        public IvalidMassageAppointmentException()
        {

        }

        public IvalidMassageAppointmentException(string error) => this.Error = error;
    }
}
