namespace RelaxAndSport.Application.Booking.MassagesSchedule
{
    using RelaxAndSport.Application.Common.Contracts;
    using RelaxAndSport.Domain.Booking.Models.MassagesAppointments;
    using RelaxAndSport.Domain.Booking.Models.MassagesSchedule;
    using System.Threading.Tasks;

    public interface IMassagesScheduleRepository : IRepository<MassagesSchedule>
    {
        Task AddMassageAppointment(MassageAppointment massageAppointment);

        Task<MassagesSchedule> GetMassagesSchedule();
    }
}
