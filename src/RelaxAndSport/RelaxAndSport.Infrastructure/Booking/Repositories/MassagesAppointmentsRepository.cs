namespace RelaxAndSport.Infrastructure.Booking.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using RelaxAndSport.Application.Booking.MassagesAppointments;
    using RelaxAndSport.Domain.Booking.Exceptions;
    using RelaxAndSport.Domain.Booking.Models.MassagesAppointments;
    using RelaxAndSport.Infrastructure.Common.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MassagesAppointmentsRepository : DataRepository<IBookingDbContext, MassageAppointment>, IMassagesAppointmentsRepository
    {
        public MassagesAppointmentsRepository(IBookingDbContext db)
            : base(db)
        {
        }

        public async Task<MassageAppointment> GetMassageAppointment(int id)
        {
            var massageAppointment = await this.Data
                .MassageAppointments
                .FirstOrDefaultAsync(ma => ma.Id == id);

            if (massageAppointment == null)
            {
                throw new InvalidMassageAppointmentException($"Massage appointment with Id {id} doesnt exists.");
            }

            return massageAppointment;
        }

        public async Task<bool> Delete(MassageAppointment massageAppointment, CancellationToken cancellationToken)
        {
            if (massageAppointment == null)
            {
                return false;
            }

            this.Data
                .MassageAppointments
                .Remove(massageAppointment);

            await this.Data
                .SaveChangesAsync();

            return true;
        }
    }
}
