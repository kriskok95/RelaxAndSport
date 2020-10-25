namespace RelaxAndSport.Domain.Booking.Repositories
{
    using RelaxAndSport.Domain.Booking.Models.MassagesAppointments;
    using RelaxAndSport.Domain.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IMassagesAppointmentsDomainRepository : IDomainRepository<MassageAppointment>
    {
        Task<MassageAppointment> GetMassageAppointment(int id);

        Task<bool> Delete(MassageAppointment massageAppointment, CancellationToken cancellationToken);
    }
}
