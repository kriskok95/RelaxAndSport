namespace RelaxAndSport.Domain.Booking.Exceptions
{
    using RelaxAndSport.Domain.Common.Exceptions;

    public class InvalidDateTimeRangeException : BaseDomainException
    {
        public InvalidDateTimeRangeException()
        {
        }

        public InvalidDateTimeRangeException(string error) => this.Error = error;
    }
}
