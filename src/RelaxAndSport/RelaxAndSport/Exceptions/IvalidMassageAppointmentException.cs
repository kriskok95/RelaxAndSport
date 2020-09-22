namespace RelaxAndSport.Domain.Exceptions
{
    public class IvalidMassageAppointmentException : BaseDomainException
    {
        public IvalidMassageAppointmentException()
        {

        }

        public IvalidMassageAppointmentException(string error) => this.Error = error;
    }
}
