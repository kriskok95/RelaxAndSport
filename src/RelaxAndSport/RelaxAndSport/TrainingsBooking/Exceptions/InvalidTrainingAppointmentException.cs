namespace RelaxAndSport.Domain.TrainingsBooking.Exceptions
{
    using RelaxAndSport.Domain.Common.Exceptions;

    public class InvalidTrainingAppointmentException : BaseDomainException
    {
        public InvalidTrainingAppointmentException()
        {

        }

        public InvalidTrainingAppointmentException(string error) => Error = error;

    }
}
