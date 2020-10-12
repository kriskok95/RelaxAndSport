namespace RelaxAndSport.Application.Booking.MassagesAppointments
{
    using RelaxAndSport.Application.Common.Contracts;
    using RelaxAndSport.Domain.Booking.Models.MassagesAppointments;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IMassagesAppointmentsRepository : IRepository<MassageAppointment>
    {
        Task<MassageAppointment> GetMassageAppointment(int id);

        Task<bool> Delete(MassageAppointment massageAppointment, CancellationToken cancellationToken);
    }
}
