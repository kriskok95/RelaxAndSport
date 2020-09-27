namespace RelaxAndSport.Domain.TrainingsBooking.Exceptions
{
    using RelaxAndSport.Domain.Common.Exceptions;

    public class InvalidTrainingException : BaseDomainException
    {
        public InvalidTrainingException()
        {

        }

        public InvalidTrainingException(string error) => this.Error = error;
    }
}
