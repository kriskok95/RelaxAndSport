using RelaxAndSport.Domain.Booking.Models.MassagesAppointments;
using RelaxAndSport.Domain.Booking.Models.MassagesSchedule;
using RelaxAndSport.Domain.Common;
using System.Threading.Tasks;

namespace RelaxAndSport.Domain.Booking.Repositories
{
    public interface IMassagesScheduleDomainRepository : IDomainRepository<MassagesSchedule>
    {
        Task AddMassageAppointment(MassageAppointment massageAppointment);

        Task<MassagesSchedule> GetMassagesSchedule();
    }
}
