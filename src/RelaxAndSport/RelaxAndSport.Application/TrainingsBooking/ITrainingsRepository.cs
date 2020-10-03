namespace RelaxAndSport.Application.TrainingsBooking
{
    using RelaxAndSport.Application.Common.Contracts;
    using RelaxAndSport.Domain.TrainingsBooking.Models.Trainings;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ITrainingsRepository : IRepository<Training>
    {
        Task<Training> Find(int id, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);

        Task<Trainer> GetTrainer(int id, CancellationToken cancellationToken = default);
    }
}
