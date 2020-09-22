namespace RelaxAndSport.Domain.Exceptions
{
    public class InvalidMassageException : BaseDomainException
    {
        public InvalidMassageException()
        {

        }

        public InvalidMassageException(string error) => this.Error = error;
    }
}
