using RelaxAndSport.Domain.Common;

namespace RelaxAndSport.Domain.Common.Exceptions
{
    public class InvalidClientException : BaseDomainException
    {
        public InvalidClientException()
        {

        }

        public InvalidClientException(string error) => this.Error = error;
    }
}
