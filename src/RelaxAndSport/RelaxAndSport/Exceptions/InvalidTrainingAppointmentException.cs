namespace RelaxAndSport.Domain.Exceptions
{
    public class InvalidTrainingAppointmentException : BaseDomainException
    {
        public InvalidTrainingAppointmentException()
        {

        }

        public InvalidTrainingAppointmentException(string error) => this.Error = error;

    }
}
