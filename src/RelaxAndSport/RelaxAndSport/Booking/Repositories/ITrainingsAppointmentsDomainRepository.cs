namespace RelaxAndSport.Domain.Booking.Repositories
{
    using RelaxAndSport.Domain.Booking.Models.TrainifngsAppointments;
    using RelaxAndSport.Domain.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ITrainingsAppointmentsDomainRepository : IDomainRepository<TrainingAppointment>
    {
        Task<TrainingAppointment> GetTrainingAppointment(int id, CancellationToken cancellationToken);
    }
}
