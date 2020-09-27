namespace RelaxAndSport.Domain.Common.Exceptions
{
    using RelaxAndSport.Domain.Common;

    public class InvalidPhoneNumberException : BaseDomainException
    {
        public InvalidPhoneNumberException()
        {

        }

        public InvalidPhoneNumberException(string error) => this.Error = error;
    }
}
