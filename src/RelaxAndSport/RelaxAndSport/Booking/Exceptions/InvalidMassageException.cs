namespace RelaxAndSport.Domain.Booking.Exceptions
{
    using RelaxAndSport.Domain.Common.Exceptions;

    public class InvalidMassageException : BaseDomainException
    {
        public InvalidMassageException()
        {

        }

        public InvalidMassageException(string error) => this.Error = error;
    }
}
