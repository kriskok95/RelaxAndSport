namespace RelaxAndSport.Domain.Booking.Repositories
{
    using RelaxAndSport.Domain.Booking.Models.Trainings;
    using RelaxAndSport.Domain.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ITrainingsDomainRepository : IDomainRepository<Training>
    {
        Task<Training> Find(int id, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);

        Task<Trainer> GetTrainer(int id, CancellationToken cancellationToken = default);

        Task<Trainer> GetTrainer(string trainerFirstName, string trainerLastName, CancellationToken cancellationToken);

        Task<Training> GetById(int id, CancellationToken cancellationToken = default);

        Task ValidateTrainingExistence(Training training, CancellationToken cancellationToken);
    }
}
