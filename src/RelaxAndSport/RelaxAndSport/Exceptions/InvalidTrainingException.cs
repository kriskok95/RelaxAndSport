namespace RelaxAndSport.Domain.Exceptions
{
    public class InvalidTrainingException : BaseDomainException
    {
        public InvalidTrainingException()
        {

        }

        public InvalidTrainingException(string error) => this.Error = error;
    }
}
